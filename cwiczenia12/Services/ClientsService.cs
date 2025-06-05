using cwiczenia12.Data;
using cwiczenia12.Exceptions;
using Microsoft.EntityFrameworkCore;


namespace cwiczenia12.Services;


public class ClientsService : IClientsService
{
    
    private readonly _2019sbdContext _context;
    
    public ClientsService(_2019sbdContext context)
    {
        _context = context;
    }
    
    public async Task<bool> DeleteClientAsync(int idClient)
    {
        var client = await _context.Cwiczenia12Clients.FindAsync(idClient);
        if (client == null)
        { 
            throw new ClientNotFoundException($"klient o id={idClient} nie istnieje");
        }
        
        var doesClientHaveTrips = await _context.Cwiczenia12ClientTrips
            .AnyAsync(ct => ct.IdClient == idClient);
        if (doesClientHaveTrips) 
        {
            throw new ClientAssignedToActiveTripsException("klient ma przypisane wycieczki -> nie można usunąć");
        }
        
        _context.Cwiczenia12Clients.Remove(client);
        await _context.SaveChangesAsync();

        return true;
    }
    
}
