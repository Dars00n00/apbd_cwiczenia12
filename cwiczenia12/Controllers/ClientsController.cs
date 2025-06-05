using Microsoft.AspNetCore.Mvc;
using cwiczenia12.Services;


namespace cwiczenia12.Controllers;

    
[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }

    
    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClientAsync(int idClient)
    {
        try
        {
            if (await _clientsService.DeleteClientAsync(idClient))
            {
                return Ok($"usunięto klienta o id={idClient}");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        return BadRequest();
    }
    
}
