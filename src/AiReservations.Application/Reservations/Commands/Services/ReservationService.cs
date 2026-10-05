using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Domain.Entities;

namespace AiReservations.Application.Reservations.Services;

public sealed class ReservationService : IReservationService
{
    public ReservationRequest Create(CreateReservationCommand command)
    {
        return new ReservationRequest(
            command.GuestName,
            command.GuestEmail,
            command.CheckIn,
            command.CheckOut,
            command.NumberOfGuests,
            command.RoomType,
            command.SpecialRequests);
    }
}