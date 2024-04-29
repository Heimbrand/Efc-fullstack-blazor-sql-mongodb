using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB.Repositories;

public class OrderProductRepository : IOrderProductService<OrderProduct>
{
    private readonly WebbHandelDbContext _context;
    public OrderProductRepository(WebbHandelDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<OrderProduct>> GetAllOrderProducts()
    {
        return await _context.OrderProducts.ToListAsync();
    }
    public async Task AddOrderProduct(OrderProduct orderProduct)
    {
        _context.OrderProducts.Add(orderProduct);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateOrderProduct(OrderProduct orderProduct)
    {
        _context.OrderProducts.Update(orderProduct);
        await _context.SaveChangesAsync();
    }
}