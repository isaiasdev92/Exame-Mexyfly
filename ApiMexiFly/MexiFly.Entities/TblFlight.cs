namespace MexiFly.Entities;


public partial class TblFlight
{
    public long FlightId { get; set; }

    public string FlightCode { get; set; } = null!;

    public string OriginAirportId { get; set; } = null!;

    public string DestinationAirportId { get; set; } = null!;

    public DateTime DepartureDateTime { get; set; }

    public int TotalSeats { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual TblAirport DestinationAirport { get; set; } = null!;

    public virtual TblAirport OriginAirport { get; set; } = null!;

    public virtual ICollection<TblRate> TblRates { get; set; } = new List<TblRate>();

    public virtual ICollection<TblSegment> TblSegments { get; set; } = new List<TblSegment>();
}
