using AiReservations.Application.Reservations.Repositories;
using AiReservations.Domain.Entities;

namespace AiReservations.UnitTests.Fakes;

public class FakeReservationRepository : IReservationRepository
{
    public ReservationRequest? SavedReservation { get; private set; }

    public Task AddAsync(
        ReservationRequest reservation,
        CancellationToken cancellationToken = default)
    {
        SavedReservation = reservation;

        return Task.CompletedTask;
    }
}