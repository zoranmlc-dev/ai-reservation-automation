using AiReservations.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiReservations.Infrastructure.Persistence.Configuration;

public sealed class ReservationRequestConfiguration
    : IEntityTypeConfiguration<ReservationRequest>
{
    public void Configure(EntityTypeBuilder<ReservationRequest> builder)
    {
        builder.ToTable("reservations");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.GuestName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(r => r.GuestEmail)
            .IsRequired()
            .HasMaxLength(320);

        builder.Property(r => r.RoomType)
            .HasMaxLength(100);

        builder.Property(r => r.Status)
            .HasConversion<string>()
            .HasMaxLength(30);
    }
}