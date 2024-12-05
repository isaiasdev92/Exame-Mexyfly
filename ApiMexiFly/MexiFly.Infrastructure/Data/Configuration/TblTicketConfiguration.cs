using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblTicketConfiguration : IEntityTypeConfiguration<TblTicket>
{
    public void Configure(EntityTypeBuilder<TblTicket> builder)
    {
        builder.HasKey(e => e.TicketId).HasName("PRIMARY");

        builder.ToTable("Tbl_Ticket", "RESERVATION_V1");

        builder.HasIndex(e => e.ClientId, "ClientId");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.IssueDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.TotalPrice).HasPrecision(10);
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.Client).WithMany(p => p.TblTickets)
            .HasForeignKey(d => d.ClientId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_ticket_ibfk_1");
    }
}
