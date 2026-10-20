using AiReservations.Application.Reservations.Repositories;
using AiReservations.Domain.Entities;

namespace AiReservations.UnitTests.Fakes;

public class FakeReservationRepository : IReservationRepository
{
    public ReservationRequest? SavedReservation { get; private set; }

    private readonly List<ReservationRequest> _reservations = new();

    public Task AddAsync(
        ReservationRequest reservation,
        CancellationToken cancellationToken = default)
    {
        SavedReservation = reservation;

        _reservations.Add(reservation);

        return Task.CompletedTask;
    }

    public Task<ReservationRequest?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        ReservationRequest? reservation =
            _reservations.FirstOrDefault(r => r.Id == id);

        return Task.FromResult(reservation);
    }
}