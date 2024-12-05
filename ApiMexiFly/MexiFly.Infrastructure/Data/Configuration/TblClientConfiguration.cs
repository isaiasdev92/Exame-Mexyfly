using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblClientConfiguration : IEntityTypeConfiguration<TblClient>
{
    public void Configure(EntityTypeBuilder<TblClient> builder)
    {
        builder.HasKey(e => e.ClientId).HasName("PRIMARY");

        builder.ToTable("Tbl_Client", "RESERVATION_V1");

        builder.HasIndex(e => e.Email, "Email").IsUnique();

        builder.HasIndex(e => e.UserId, "UserId");

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastNameM).HasMaxLength(100);
        builder.Property(e => e.LastNameP).HasMaxLength(100);
        builder.Property(e => e.PhoneNumber).HasMaxLength(15);
        builder.Property(e => e.RegistrationDate)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.User).WithMany(p => p.TblClients)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_client_ibfk_1");
    }
}
