namespace MexiFly.Entities;

public partial class TblTicket
{
    public long TicketId { get; set; }

    public long ClientId { get; set; }

    public DateTime? IssueDate { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual TblClient Client { get; set; } = null!;

    public virtual ICollection<TblSegment> TblSegments { get; set; } = new List<TblSegment>();
}
