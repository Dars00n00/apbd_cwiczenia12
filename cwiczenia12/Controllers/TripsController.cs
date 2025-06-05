using cwiczenia12.Models;
using cwiczenia12.Services;
using Microsoft.AspNetCore.Mvc;


namespace cwiczenia12.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    
    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetTripsAsync(int? page, int? pageSize)
    {
        return Ok(await _tripsService.GetTripsAsync(page, pageSize));
    }
    
    
    //przykładowy POST
    // id=1
    // {
    //     "FirstName": "John",
    //     "LastName": "Doe",
    //     "Email": "doe@wp.pl",
    //     "Telephone": "543-323-542",
    //     "Pesel": "91040294554",
    //     "PaymentDate": "2021-04-20T00:00:00"
    // }
    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] AssignClientDto clientDto)
    {
        try
        {
            if (await _tripsService.AssignClientToTripAsync(idTrip, clientDto))
            {
                return Ok();
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
        return BadRequest();
    }
    
}