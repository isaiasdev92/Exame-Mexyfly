namespace MexiFly.Entities;

public partial class TblAirport
{
    public string AirportId { get; set; } = null!;

    public string NameAirport { get; set; } = null!;

    public string? City { get; set; }

    public string? Country { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual ICollection<TblFlight> TblFlightDestinationAirports { get; set; } = new List<TblFlight>();

    public virtual ICollection<TblFlight> TblFlightOriginAirports { get; set; } = new List<TblFlight>();
}
