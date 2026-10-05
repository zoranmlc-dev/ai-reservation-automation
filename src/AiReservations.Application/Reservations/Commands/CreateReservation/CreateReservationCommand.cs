namespace AiReservations.Application.Reservations.Commands.CreateReservation;

public sealed record CreateReservationCommand(
    string GuestName,
    string GuestEmail,
    DateOnly CheckIn,
    DateOnly CheckOut,
    int NumberOfGuests,
    string? RoomType,
    string? SpecialRequests);