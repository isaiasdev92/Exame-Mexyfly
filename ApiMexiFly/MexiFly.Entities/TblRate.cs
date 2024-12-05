namespace MexiFly.Entities;


public partial class TblRate
{
    public long RateId { get; set; }

    public long FlightId { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblFlight Flight { get; set; } = null!;
}
