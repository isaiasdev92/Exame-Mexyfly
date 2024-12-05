using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblUserConfiguration : IEntityTypeConfiguration<TblUser>
{
    public void Configure(EntityTypeBuilder<TblUser> builder)
    {
        builder.HasKey(e => e.UserId).HasName("PRIMARY");

        builder.ToTable("Tbl_User", "RESERVATION_V1");

        builder.HasIndex(e => e.Username, "Username").IsUnique();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.IsActive).HasDefaultValueSql("'1'");
        builder.Property(e => e.PasswordHash).HasMaxLength(255);
        builder.Property(e => e.RoleUser).HasColumnType("enum('Admin','Client')");
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");
        builder.Property(e => e.Username).HasMaxLength(50);
    }
}
