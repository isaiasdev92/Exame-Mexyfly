using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblRateConfiguration : IEntityTypeConfiguration<TblRate>
{
    public void Configure(EntityTypeBuilder<TblRate> builder)
    {
        builder.HasKey(e => e.RateId).HasName("PRIMARY");

        builder.ToTable("Tbl_Rate", "RESERVATION_V1");

        builder.HasIndex(e => e.CategoryId, "CategoryId");

        builder.HasIndex(e => e.FlightId, "FlightId");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.Price).HasPrecision(10);
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.Category).WithMany(p => p.TblRates)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_rate_ibfk_2");

        builder.HasOne(d => d.Flight).WithMany(p => p.TblRates)
            .HasForeignKey(d => d.FlightId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_rate_ibfk_1");
    }
}
