using AiReservations.Application.Reservations.Commands.CreateReservation;
using AiReservations.Domain.Entities;
using AiReservations.Application.Reservations.Repositories;

namespace AiReservations.Application.Reservations.Services;

public sealed class ReservationService : IReservationService
{
    private readonly IReservationRepository _repository;

    public ReservationService(IReservationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ReservationRequest> CreateAsync(
        CreateReservationCommand command,
        CancellationToken cancellationToken = default)
    {
        var reservation = new ReservationRequest(
            command.GuestName,
            command.GuestEmail,
            command.CheckIn,
            command.CheckOut,
            command.NumberOfGuests,
            command.RoomType,
            command.SpecialRequests);

        await _repository.AddAsync(reservation, cancellationToken);

        return reservation;
    }
}