using System.Linq;
using Public.Domain.Entities;
using Public.Domain.Interfaces;


namespace Public.API.Data;

// Seedar en default style vid uppstart om ingen finns
// Går direkt mot repository istället för service-lagret, ingen affärslogik krävs här
// Hade behövt mer kod om jag gått via service-lagret eftersom servicens CreateAsync inte tar emot IsActive,
// då hade jag behövt skapa, sen hämta id:t, sen aktivera.
public class SiteStyleSeeder
{
    public static async Task SeedDefaultStyleAsync(IServiceProvider serviceProvider)
    {
        var repo = serviceProvider.GetRequiredService<ISiteStyleRepository>();
        
        var existing = await repo.GetSiteStylesAsync();
        
        if (existing.Any()) return;

        var defaultStyle = new SiteStyle()
        {
            Name = "Default",
            IsActive = true
        };
        await repo.CreateSiteStyleAsync(defaultStyle);
    }
    
}