using AiReservations.Domain.Enums;

namespace AiReservations.Domain.Entities;

public class ReservationRequest
{
    public Guid Id { get; private set; }

    public string GuestName { get; private set; }
    public string GuestEmail { get; private set; }

    public DateOnly CheckIn { get; private set; }
    public DateOnly CheckOut { get; private set; }

    public int NumberOfGuests { get; private set; }
    
    public string? RoomType { get; private set; }
    public string? SpecialRequests { get; private set; }

    public ReservationStatus Status { get; private set; }

    public ReservationRequest(
        string guestName,
        string guestEmail,
        DateOnly checkIn,
        DateOnly checkOut,
        int numberOfGuests,
        string? roomType = null,
        string? specialRequests = null)
    {
        Id = Guid.NewGuid();

        GuestName = guestName;
        GuestEmail = guestEmail;
        CheckIn = checkIn;
        CheckOut = checkOut;
        NumberOfGuests = numberOfGuests;
        RoomType = roomType;
        SpecialRequests = specialRequests;

        Status = ReservationStatus.Pending;
    }

}