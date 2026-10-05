using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Domain.Entities;

namespace AiReservations.Application.Reservations.Services;

public interface IReservationService
{
    ReservationRequest Create(CreateReservationCommand command);
}