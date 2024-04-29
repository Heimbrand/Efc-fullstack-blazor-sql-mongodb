namespace Labb2WebbTemplate.Common.Entities;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public virtual ICollection<OrderProduct> Products { get; set; }
    public DateTime DateTime { get; set; }
}


