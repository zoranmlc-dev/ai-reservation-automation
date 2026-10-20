using AiReservations.Domain.Entities;

namespace AiReservations.Application.Reservations.Repositories;

public interface IReservationRepository
{
    Task AddAsync(
        ReservationRequest reservation,
        CancellationToken cancellationToken = default);

    Task<ReservationRequest?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}
