using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Application.Reservations.Services;
using AiReservations.Domain.Enums;
using AiReservations.UnitTests.Fakes;

namespace AiReservations.UnitTests.Application.Reservations;

public class ReservationServiceTests
{
    [Fact]
    public async Task Create_Should_Create_Pending_Reservation()
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

        var repository = new FakeReservationRepository();
        var service = new ReservationService(repository);

        // Act
        var reservation = await service.CreateAsync(command);

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
        Assert.Same(reservation, repository.SavedReservation);
    }

    [Fact]
    public async Task Create_Should_Throw_When_CheckOut_Is_Before_CheckIn()
    {
        // Arrange
        var command = new CreateReservationCommand(
            GuestName: "Petar Petrovic",
            GuestEmail: "petrovic@example.com",
            CheckIn: new DateOnly(2026, 11, 15),
            CheckOut: new DateOnly(2026, 11, 10),
            NumberOfGuests: 2,
            RoomType: null,
            SpecialRequests: null
        );

        var repository = new FakeReservationRepository();
        var service = new ReservationService(repository);

        // Act
        var act = async () => await service.CreateAsync(command);

        // Assert
        await Assert.ThrowsAsync<AiReservations.Domain.Common.DomainException>(act);
        Assert.Null(repository.SavedReservation);
    }
}