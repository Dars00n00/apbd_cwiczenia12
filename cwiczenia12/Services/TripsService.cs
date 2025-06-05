using cwiczenia12.Data;
using cwiczenia12.Exceptions;
using cwiczenia12.Models;
using Microsoft.EntityFrameworkCore;


namespace cwiczenia12.Services;


public class TripsService : ITripsService
{
    private readonly _2019sbdContext _context;
    
    public TripsService(_2019sbdContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Cwiczenia12Trip>> GetTripsAsync(int? page, int? pageSize)
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

        return tripsQueried;
    }
    
    public async Task<bool> AssignClientToTripAsync(int idTrip, AssignClientDto clientDto)
    {
        var trip = await _context.Cwiczenia12Trips.FindAsync(idTrip);
        if (trip == null)
        {
            throw new TripNotFoundException($"wycieczka o id={idTrip} nie istnieje");
        }
        if (trip.DateFrom <= DateTime.Now)
        {
            throw new TripNotAvailableException($"wycieczka już się odbyła, data wycieczki={trip.DateFrom}, dzisiejsza data={DateTime.Now}");
        }

        
        var client = await _context.Cwiczenia12Clients
            .FirstOrDefaultAsync(c => c.Pesel == clientDto.Pesel);
        if (client == null)
        {
            client = new Cwiczenia12Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Telephone = clientDto.Telephone,
                Pesel = clientDto.Pesel
            };

            _context.Cwiczenia12Clients.Add(client);
            await _context.SaveChangesAsync();
        }
        
        
        var isClientAlreadyAssignedToTrip = await _context.Cwiczenia12ClientTrips
            .AnyAsync(ct => ct.IdClient == client.IdClient && ct.IdTrip == idTrip);
        if (isClientAlreadyAssignedToTrip)
        {
            throw new ClientAlreadyAssignedToTripException("klient już jest zapisany na tę wycieczkę");
        }
        
        var clientTrip = new Cwiczenia12ClientTrip
        {
            IdClient = client.IdClient,
            IdTrip = idTrip,
            RegisteredAt = DateTime.Now,
            PaymentDate = clientDto.PaymentDate
        };

        await _context.Cwiczenia12ClientTrips.AddAsync(clientTrip);
        await _context.SaveChangesAsync();

        return true;
    }
    
}