namespace Labb2WebbTemplate.Common.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public virtual List<OrderProductDto> Products { get; set; }
    public DateTime DateTime { get; set; }
}