using Microsoft.EntityFrameworkCore;
using Public.API.Data;
using Public.Application.Interfaces;
using Public.Application.Services;
using Public.Domain.Interfaces;
using Public.Infrastructure.Data;
using Public.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();   

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString"))); 

builder.Services.AddScoped<IPageRepository, PageRepository>();                             
builder.Services.AddScoped<IContentBlockRepository, ContentBlockRepository>();             
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<ISiteStyleRepository, SiteStyleRepository>();

builder.Services.AddScoped<IPageService, PageService>();
builder.Services.AddScoped<IContentBlockService, ContentBlockService>();
builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddScoped<ISiteStyleService, SiteStyleService>();

// CORS: tillåt UI (både lokalt och Azure) att anropa API:t
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "http://localhost:5048",
                "https://anton-public-ui.azurewebsites.net")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await SiteStyleSeeder.SeedDefaultStyleAsync(scope.ServiceProvider);
}


// Så att filerna kan nås via URL, bilderna tex
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())                                                       
{
    app.UseSwagger();                                                                      
    app.UseSwaggerUI();                         
}  

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();