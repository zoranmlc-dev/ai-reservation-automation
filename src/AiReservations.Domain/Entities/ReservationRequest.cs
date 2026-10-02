using AiReservations.Domain.Enums;
using AiReservations.Domain.Common;

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
        Validate(
            guestName,
            guestEmail,
            checkIn,
            checkOut,
            numberOfGuests);
            
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

    private static void Validate(
        string guestName,
        string guestEmail,
        DateOnly checkIn,
        DateOnly checkOut,
        int numberOfGuests)
    {
        if(string.IsNullOrWhiteSpace(guestName))
            throw new DomainException("Guest name is required.");

        if(string.IsNullOrWhiteSpace(guestEmail))
            throw new DomainException("Guest email is required.");

        if(checkOut <= checkIn)
            throw new DomainException("Check-out date must be after check-in date.");

        if(numberOfGuests <=0)
            throw new DomainException("Number of guests must be greater than zero.");
    }

}