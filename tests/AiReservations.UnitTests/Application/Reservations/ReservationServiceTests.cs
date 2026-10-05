using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Application.Reservations.Services;
using AiReservations.Domain.Enums;

namespace AiReservations.UnitTests.Application.Reservations;

public class ReservationServiceTests
{
    [Fact]
    public void Create_Should_Create_Pending_Reservation()
    {
        // Arrange
        var command = new CreateReservationCommand(
            GuestName: "Petar Petrovic",
            GuestEmail: "petrovic@example.com",
            CheckIn: new DateOnly(2026, 10, 12),
            CheckOut: new DateOnly(2026, 10, 16),
            NumberOfGuests: 2,
            RoomType: "Studio Central",
            SpecialRequests: "Late check-in");

        var service = new ReservationService();

        // Act
        var reservation = service.Create(command);

        // Assert
        Assert.NotEqual(Guid.Empty, reservation.Id);
        Assert.Equal("Petar Petrovic", reservation.GuestName);
        Assert.Equal("petrovic@example.com", reservation.GuestEmail);
        Assert.Equal(new DateOnly(2026, 10, 12), reservation.CheckIn);
        Assert.Equal(new DateOnly(2026, 10, 16), reservation.CheckOut);
        Assert.Equal(2, reservation.NumberOfGuests);
        Assert.Equal("Studio Central", reservation.RoomType);
        Assert.Equal("Late check-in", reservation.SpecialRequests);
        Assert.Equal(ReservationStatus.Pending, reservation.Status);
    }
}