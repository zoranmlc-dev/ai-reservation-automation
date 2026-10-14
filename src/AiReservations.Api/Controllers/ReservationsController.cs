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
    public async Task<IActionResult> Create(
        [FromBody] CreateReservationRequest request,
        CancellationToken cancellationToken)
    {
        var command = new CreateReservationCommand(
            request.GuestName,
            request.GuestEmail,
            request.CheckIn,
            request.CheckOut,
            request.NumberOfGuests,
            request.RoomType,
            request.SpecialRequests);

        var reservation = await _reservationService.CreateAsync(
            command,
            cancellationToken);

        return Ok(new
        {
            reservation.Id,
            reservation.Status
        });
    }
}