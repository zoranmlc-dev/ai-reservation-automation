using AiReservations.Domain.Entities;

namespace AiReservations.Api.Models.Reservations;

public static class ReservationMappingExtensions
{
    public static ReservationResponse ToResponse(
        this ReservationRequest reservation)
    {
        return new ReservationResponse(
            Id: reservation.Id,
            GuestName: reservation.GuestName,
            GuestEmail: reservation.GuestEmail,
            CheckIn: reservation.CheckIn,
            CheckOut: reservation.CheckOut,
            NumberOfGuests: reservation.NumberOfGuests,
            RoomType: reservation.RoomType,
            SpecialRequests: reservation.SpecialRequests,
            Status: reservation.Status.ToString()
        );
    }
}