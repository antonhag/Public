using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Public.Domain.Entities;
using Public.UI.Components;
using Public.UI.Components.Account;
using Public.UI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));

// HttpClient som pratar med API:t
builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5189");
});

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<AppUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
    })
    .AddRoles<IdentityRole>()    
    .AddEntityFrameworkStores<AuthDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<AppUser>, IdentityNoOpEmailSender>();


var app = builder.Build();


// Seedar roller Admin och Editor och första admin-usern vid uppstart.
// Annars hade man behövt skapa rollerna och göra någon user till admin via SQL
// Detta löser problemet att ingen kan tilldela admin-rollen om ingen är admin från början

// Skapa en scope — DI-tjänster som är "Scoped" (UserManager, RoleManager, DbContext) 
// behöver leva inom en scope. Top-level Program.cs har ingen request-scope by default,
// så vi skapar en manuellt här.
using (var scope = app.Services.CreateScope())
{
    // Hämta RoleManager från DI — används för att skapa/kolla roller (AspNetRoles-tabellen)
    var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    
    // Hämta UserManager — används för att skapa users, sätta lösenord, tilldela roller
    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
  
    // Loopa igenom rollnamnen vi vill ha, om de inte redan finns i AspNetroles så skapar vi dem. dubletter skapas ej vid ny uppstart
    foreach (var role in new[] { "Admin", "Editor" })
        if (!await roleMgr.RoleExistsAsync(role))
            await roleMgr.CreateAsync(new IdentityRole(role));

    // seedar den första admin-användaren vi vill seeda, istället för att lägga in den manuellt med SQL
    var adminEmail = "admin@test.se";
    
    // Letar upp användaren med den angivna email ovan i AspNetUsers
    var admin = await userMgr.FindByEmailAsync(adminEmail);
    
    // Om användaren inte finns så skapar vi den
    if (admin is null)
    {
        admin = new AppUser { UserName = adminEmail, Email = adminEmail, EmailConfirmed =
            true };
        await userMgr.CreateAsync(admin, "Admin123!");
    }
    
    // Kolla om användaren redan har admin-rollen, skyddar även mot dubblett-tilldelning
    if (!await userMgr.IsInRoleAsync(admin, "Admin"))
        // Lägger till kopplingen mellan user och role i AspNetUserRoles-tabellen
        await userMgr.AddToRoleAsync(admin, "Admin");
    
} // Här disposar vi scopet och städar upp automatiskt

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapAdditionalIdentityEndpoints();

app.Run();

