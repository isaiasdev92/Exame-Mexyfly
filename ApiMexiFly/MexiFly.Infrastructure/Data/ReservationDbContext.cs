using System.Reflection;
using MexiFly.Entities;
using Microsoft.EntityFrameworkCore;

namespace MexiFly.Infrastructure.Data;

public partial class MexiflyDbContext : DbContext
{
    public MexiflyDbContext()
    {
    }

    public MexiflyDbContext(DbContextOptions<MexiflyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAirport> TblAirports { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblClient> TblClients { get; set; }

    public virtual DbSet<TblFlight> TblFlights { get; set; }

    public virtual DbSet<TblRate> TblRates { get; set; }

    public virtual DbSet<TblSegment> TblSegments { get; set; }

    public virtual DbSet<TblTicket> TblTickets { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserInfo> TblUserInfos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
