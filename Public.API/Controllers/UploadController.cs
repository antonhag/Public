using Microsoft.AspNetCore.Mvc;
namespace Public.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public UploadController(IWebHostEnvironment env)
    {
        _env = env;
    }
    
    [HttpPost]
    public async Task<string> Upload(IFormFile file)
    {
        var uploadsPath = Path.Combine(_env.WebRootPath, "uploads"); // Bygger sökvägen till uploads mappen
        Directory.CreateDirectory(uploadsPath); // Skapar mappen om den inte finns, ifall den inte finns görs inget

        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // Genererar ett unikt filnamn
        
        // Öppnar ny fil för skrivning, using gör så att den stänger filen automatiskt när den är klar
        using var stream = new FileStream(Path.Combine(uploadsPath, fileName), FileMode.Create); // Kopierar uppladdad fil till disk
        await file.CopyToAsync(stream); // Returnerar sökvägen som sparas i DB

        return $"/uploads/{fileName}";
    }
}