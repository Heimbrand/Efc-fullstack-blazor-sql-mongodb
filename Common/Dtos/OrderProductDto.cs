using Labb2WebbTemplate.Common.Entities;

namespace Labb2WebbTemplate.Common.Dtos;

public class OrderProductDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}