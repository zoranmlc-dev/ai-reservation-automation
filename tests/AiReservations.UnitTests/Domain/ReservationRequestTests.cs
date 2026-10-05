using AiReservations.Domain.Entities;
using AiReservations.Domain.Enums;
using AiReservations.Domain.Common;

namespace AiReservations.UnitTests.Domain;

public class ReservationRequestTests
{
    [Fact]
    public void Should_Create_Valid_Reservation_Request()
    {
        var reservation = new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 1),
            checkOut: new DateOnly(2026, 10, 6),
            numberOfGuests: 2,
            roomType: "Studio Central",
            specialRequests: "Late check-in");

        Assert.NotEqual(Guid.Empty, reservation.Id);
        Assert.Equal("Petar Petrovic", reservation.GuestName);
        Assert.Equal("petrovic@example.com", reservation.GuestEmail);
        Assert.Equal(new DateOnly(2026, 10, 1), reservation.CheckIn);
        Assert.Equal(new DateOnly(2026, 10, 6), reservation.CheckOut);
        Assert.Equal(2, reservation.NumberOfGuests);
        Assert.Equal("Studio Central", reservation.RoomType);
        Assert.Equal("Late check-in", reservation.SpecialRequests);
        Assert.Equal(ReservationStatus.Pending, reservation.Status);
    }

    [Fact]
    public void Should_Reject_Empty_Guest_Name()
    {
        var act = () => new ReservationRequest(
            guestName: "",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 1),
            checkOut: new DateOnly(2026, 10, 6),
            numberOfGuests: 2);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Reject_Empty_Guest_Email()
    {
        var act = () => new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "",
            checkIn: new DateOnly(2026, 10, 1),
            checkOut: new DateOnly(2026, 10, 6),
            numberOfGuests: 2);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Reject_CheckOut_Before_CheckIn()
    {
        var act = () => new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 6),
            checkOut: new DateOnly(2026, 10, 2),
            numberOfGuests: 2);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Reject_CheckOut_Equal_To_CheckIn()
    {
        var act = () => new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 2),
            checkOut: new DateOnly(2026, 10, 2),
            numberOfGuests: 2);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Reject_Zero_Guests()
    {
        var act = () => new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 1),
            checkOut: new DateOnly(2026, 10, 6),
            numberOfGuests: 0);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Reject_Negative_Guests()
    {
        var act = () => new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 1),
            checkOut: new DateOnly(2026, 10, 6),
            numberOfGuests: -1);

        Assert.Throws<DomainException>(act);
    }

    [Fact]
    public void Should_Validate_Pending_Reservation()
    {
        var reservation = CreateValidReservation();

        reservation.Validate();

        Assert.Equal(
            ReservationStatus.Validated,
            reservation.Status);
    }

    [Fact]
    public void Should_Confirm_Validated_Reservation()
    {
        var reservation = CreateValidReservation();

        reservation.Validate();
        reservation.Confirm();

        Assert.Equal(
            ReservationStatus.Confirmed,
            reservation.Status);
    }

    [Fact]
    public void Should_Not_Confirm_Pending_Reservation()
    {
        var reservation = CreateValidReservation();

        var act = () => reservation.Confirm();

        Assert.Throws<DomainException>(act);
        Assert.Equal(ReservationStatus.Pending, reservation.Status);
    }

    [Fact]
    public void Should_Not_Validate_Reservation_Twice()
    {
        var reservation = CreateValidReservation();
        reservation.Validate();

        var act = () => reservation.Validate();

        Assert.Throws<DomainException>(act);
        Assert.Equal(ReservationStatus.Validated, reservation.Status);
    }

    [Fact]
    public void Should_Not_Reject_Confirmed_Reservation()
    {
        var reservation = CreateValidReservation();
        reservation.Validate();
        reservation.Confirm();

        var act = () => reservation.Reject();

        Assert.Throws<DomainException>(act);
        Assert.Equal(ReservationStatus.Confirmed, reservation.Status);
    }

    [Fact]
    public void Should_Not_Cancel_Rejected_Reservation()
    {
        var reservation = CreateValidReservation();
        reservation.Reject();

        var act = () => reservation.Cancel();

        Assert.Throws<DomainException>(act);
        Assert.Equal(ReservationStatus.Rejected, reservation.Status);
    }

    private static ReservationRequest CreateValidReservation()
    {
        return new ReservationRequest(
            guestName: "Petar Petrovic",
            guestEmail: "petrovic@example.com",
            checkIn: new DateOnly(2026, 10, 12),
            checkOut: new DateOnly(2026, 10, 16),
            numberOfGuests: 2,
            roomType: "Studio Central",
            specialRequests: "Late check-in");
    }
}