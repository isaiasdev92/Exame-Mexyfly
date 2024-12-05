using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblAirportConfiguration : IEntityTypeConfiguration<TblAirport>

{
    public void Configure(EntityTypeBuilder<TblAirport> builder)
    {
        builder.HasKey(e => e.AirportId).HasName("PRIMARY");

        builder.ToTable("Tbl_Airport", "RESERVATION_V1");

        builder.Property(e => e.AirportId)
            .HasMaxLength(3)
            .IsFixedLength();
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.NameAirport).HasMaxLength(100);
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
    }
}
