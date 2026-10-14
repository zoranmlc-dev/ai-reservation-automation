using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Domain.Entities;

namespace AiReservations.Application.Reservations.Services;

public interface IReservationService
{
    Task<ReservationRequest> CreateAsync(
        CreateReservationCommand command,
        CancellationToken cancellationToken = default);
}