namespace AiReservations.Api.Models.Reservations;

public sealed record ReservationResponse(
    Guid Id,
    string GuestName,
    string GuestEmail,
    DateOnly CheckIn,
    DateOnly CheckOut,
    int NumberOfGuests,
    string? RoomType,
    string? SpecialRequests,
    string Status
);