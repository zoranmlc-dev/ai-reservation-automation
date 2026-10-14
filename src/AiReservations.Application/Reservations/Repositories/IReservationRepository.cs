using AiReservations.Domain.Entities;

namespace AiReservations.Application.Reservations.Repositories;

public interface IReservationRepository
{
    Task AddAsync(
        ReservationRequest reservation,
        CancellationToken cancellationToken = default);
}
