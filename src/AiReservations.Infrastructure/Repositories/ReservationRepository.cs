using AiReservations.Application.Reservations.Repositories;
using AiReservations.Domain.Entities;
using AiReservations.Infrastructure.Persistence;

namespace AiReservations.Infrastructure.Repositories;

public sealed class ReservationRepository : IReservationRepository
{
    private readonly AiReservationsDbContext _dbContext;

    public ReservationRepository(AiReservationsDbContext dbContext)

    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(
        ReservationRequest reservation,
        CancellationToken cancellationToken = default)
    {
        await _dbContext.Reservations.AddAsync(
            reservation,
            cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}