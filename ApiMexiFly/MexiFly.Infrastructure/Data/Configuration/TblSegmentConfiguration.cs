using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblSegmentConfiguration : IEntityTypeConfiguration<TblSegment>
{
    public void Configure(EntityTypeBuilder<TblSegment> builder)
    {
        builder.HasKey(e => e.SegmentId).HasName("PRIMARY");

        builder.ToTable("Tbl_Segment", "RESERVATION_V1");

        builder.HasIndex(e => e.FlightId, "FlightId");

        builder.HasIndex(e => e.TicketId, "TicketId");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.SeatNumber).HasMaxLength(5);
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.Flight).WithMany(p => p.TblSegments)
            .HasForeignKey(d => d.FlightId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_segment_ibfk_2");

        builder.HasOne(d => d.Ticket).WithMany(p => p.TblSegments)
            .HasForeignKey(d => d.TicketId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_segment_ibfk_1");
    }
}
