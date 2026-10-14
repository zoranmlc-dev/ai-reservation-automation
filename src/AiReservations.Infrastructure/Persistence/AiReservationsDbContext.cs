using AiReservations.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AiReservations.Infrastructure.Persistence;

public sealed class AiReservationsDbContext : DbContext
{
    public AiReservationsDbContext(
        DbContextOptions<AiReservationsDbContext> options)
        :base(options)
    {
    }

    public DbSet<ReservationRequest> Reservations => Set<ReservationRequest>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(AiReservationsDbContext).Assembly);
    }
}