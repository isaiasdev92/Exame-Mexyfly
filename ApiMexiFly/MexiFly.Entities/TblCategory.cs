namespace MexiFly.Entities;


public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<TblRate> TblRates { get; set; } = new List<TblRate>();
}
