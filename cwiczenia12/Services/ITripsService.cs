using cwiczenia12.Models;


namespace cwiczenia12.Services;


public interface ITripsService
{
    
    Task<IEnumerable<Cwiczenia12Trip>> GetTripsAsync(int? page, int? pageSize);
    
    Task<bool> AssignClientToTripAsync(int idTrip, AssignClientDto clientDto);
    
}