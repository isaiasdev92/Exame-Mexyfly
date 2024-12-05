using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblFlightConfiguration : IEntityTypeConfiguration<TblFlight>
{
    public void Configure(EntityTypeBuilder<TblFlight> builder)
    {
        builder.HasKey(e => e.FlightId).HasName("PRIMARY");

        builder.ToTable("Tbl_Flight", "RESERVATION_V1");

        builder.HasIndex(e => e.DestinationAirportId, "DestinationAirportId");

        builder.HasIndex(e => e.FlightCode, "FlightCode").IsUnique();

        builder.HasIndex(e => e.OriginAirportId, "OriginAirportId");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.DepartureDateTime).HasColumnType("datetime");
        builder.Property(e => e.DestinationAirportId)
            .HasMaxLength(3)
            .IsFixedLength();
        builder.Property(e => e.FlightCode).HasMaxLength(10);
        builder.Property(e => e.OriginAirportId)
            .HasMaxLength(3)
            .IsFixedLength();
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.DestinationAirport).WithMany(p => p.TblFlightDestinationAirports)
            .HasForeignKey(d => d.DestinationAirportId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_flight_ibfk_2");

        builder.HasOne(d => d.OriginAirport).WithMany(p => p.TblFlightOriginAirports)
            .HasForeignKey(d => d.OriginAirportId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_flight_ibfk_1");
    }
}
