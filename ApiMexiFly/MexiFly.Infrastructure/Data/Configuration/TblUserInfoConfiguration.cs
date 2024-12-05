using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblUserInfoConfiguration : IEntityTypeConfiguration<TblUserInfo>
{
    public void Configure(EntityTypeBuilder<TblUserInfo> builder)
    {
        builder.HasKey(e => e.UserInfoId).HasName("PRIMARY");

        builder.ToTable("Tbl_UserInfo", "RESERVATION_V1");

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
        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .HasColumnType("datetime");

        builder.HasOne(d => d.User).WithMany(p => p.TblUserInfos)
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("tbl_userinfo_ibfk_1");
    }
}
