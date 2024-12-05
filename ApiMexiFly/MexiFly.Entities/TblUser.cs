namespace MexiFly.Entities;


public partial class TblUser
{
    public long UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string RoleUser { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public virtual ICollection<TblClient> TblClients { get; set; } = new List<TblClient>();

    public virtual ICollection<TblUserInfo> TblUserInfos { get; set; } = new List<TblUserInfo>();
}
