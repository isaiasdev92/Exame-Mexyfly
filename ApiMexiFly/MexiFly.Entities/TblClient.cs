namespace MexiFly.Entities;


public partial class TblClient
{
    public long ClientId { get; set; }

    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastNameP { get; set; } = null!;

    public string? LastNameM { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual ICollection<TblTicket> TblTickets { get; set; } = new List<TblTicket>();

    public virtual TblUser User { get; set; } = null!;
}
