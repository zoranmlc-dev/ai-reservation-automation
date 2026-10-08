using AiReservations.Api.Models.Reservations;
using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Application.Reservations.Services;
using Microsoft.AspNetCore.Mvc;

namespace AiReservations.Api.Controllers;

[ApiController]
[Route("api/reservations")]
public sealed class ReservationsController : ControllerBase
{
    private readonly IReservationService _reservationService;

    public ReservationsController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public IActionResult Create(
        [FromBody] CreateReservationRequest request)
    {
        var command = new CreateReservationCommand(
            request.GuestName,
            request.GuestEmail,
            request.CheckIn,
            request.CheckOut,
            request.NumberOfGuests,
            request.RoomType,
            request.SpecialRequests);

        var reservation = _reservationService.Create(command);

        return Ok(new
        {
            reservation.Id,
            reservation.Status
        });
    }
}