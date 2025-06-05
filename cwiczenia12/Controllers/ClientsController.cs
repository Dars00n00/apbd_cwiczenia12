using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cwiczenia12.Data;


namespace cwiczenia12.Controllers;

    
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    
    private readonly _2019sbdContext _context;

    public ClientsController(_2019sbdContext context)
    {
        _context = context;
    }

    
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        var client = await _context.Cwiczenia12Clients.FindAsync(idClient);
        if (client == null)
        { 
            return NotFound($"klient o id={idClient} nie istnieje");
        }
        
        var doesClientHaveTrips = await _context.Cwiczenia12ClientTrips
            .AnyAsync(ct => ct.IdClient == idClient);

        if (doesClientHaveTrips) 
        {
            return BadRequest("klient ma przypisane wycieczki -> nie można usunąć");
        }
        
        _context.Cwiczenia12Clients.Remove(client);
        await _context.SaveChangesAsync();
        
        return Ok($"usunięto klienta o id={idClient}");
    }
    
}
