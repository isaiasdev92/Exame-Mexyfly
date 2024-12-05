using System;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Data.Configuration;

public class TblCategoryConfiguration : IEntityTypeConfiguration<TblCategory>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TblCategory> builder)
    {
        builder.HasKey(e => e.CategoryId).HasName("PRIMARY");

        builder.ToTable("Tbl_Category", "RESERVATION_V1");

        builder.HasIndex(e => e.CategoryName, "CategoryName").IsUnique();

        builder.Property(e => e.CategoryName).HasMaxLength(50);
    }
}
