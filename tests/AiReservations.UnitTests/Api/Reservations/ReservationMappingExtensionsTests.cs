using Xunit;
using AiReservations.Domain.Entities;
using AiReservations.Api.Models.Reservations;

namespace AiReservations.UnitTests.Api.Reservations;

public class ReservationMappingExtensionTests
{
    [Fact]
    public void ToResponse_Should_Map_Reservation_Correctly()
    {
        // Arrange
        ReservationRequest reservation = new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petar@example.com",
            checkIn: new DateOnly(2026, 11, 15),
            checkOut: new DateOnly(2026, 11, 20),
            numberOfGuests: 2,
            roomType: "Studio Central",
            specialRequests:"Parking mesto"
        );

        // Act
        ReservationResponse response = reservation.ToResponse();

        // Assert
        Assert.Equal(reservation.Id, response.Id);
        Assert.Equal(reservation.GuestName, response.GuestName);
        Assert.Equal(reservation.CheckIn, response.CheckIn);
        Assert.Equal(reservation.RoomType, response.RoomType);
        Assert.Equal("Pending", response.Status);
    }
}