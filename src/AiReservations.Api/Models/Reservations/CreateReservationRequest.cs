namespace AiReservations.Api.Models.Reservations;

public sealed record CreateReservationRequest(
    string GuestName,
    string GuestEmail,
    DateOnly CheckIn,
    DateOnly CheckOut,
    int NumberOfGuests,
    string? RoomType,
    string? SpecialRequests);
