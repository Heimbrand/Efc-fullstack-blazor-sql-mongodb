using Labb2WebbTemplate.Common.Entities;

namespace Labb2WebbTemplate.Common.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int StockBalance { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; }
}