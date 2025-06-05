using cwiczenia12.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace cwiczenia12.Controllers;


[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    private readonly _2019sbdContext _context;

    
    public TripsController(_2019sbdContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetTripsAsync(int? page, int? pageSize)
    {
        var actualPage = page ?? 1;
        var actualPageSize = pageSize ?? 10;

        if (actualPage <= 0) 
            actualPage = 1;
        if (actualPageSize <= 0) 
            actualPageSize = 10;

        var tripsQuery = _context.Cwiczenia12Trips
            .OrderByDescending(t => t.DateFrom);

        var tripsQueried = await tripsQuery
            .Skip((actualPage - 1) * actualPageSize)
            .Take(actualPageSize)
            .ToListAsync();

        return Ok(tripsQueried);
    }
    
}