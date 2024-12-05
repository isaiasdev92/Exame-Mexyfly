namespace MexiFly.Entities;


public partial class TblSegment
{
    public long SegmentId { get; set; }

    public long TicketId { get; set; }

    public long FlightId { get; set; }

    public string? SeatNumber { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual TblFlight Flight { get; set; } = null!;

    public virtual TblTicket Ticket { get; set; } = null!;
}
