using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB.Repositories;

public class OrderRepository : IOrderService<Order>
{
    private readonly WebbHandelDbContext _context;
    public OrderRepository(WebbHandelDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Order>> GetAllOrders()
    {
        return await _context.Orders.ToListAsync();
    }
    public async Task<IEnumerable<Order>> GetOrdersByCustomerId(int customerId)
    {
        return await _context.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
    }
    public async Task<Order> GetOrderById(int id)
    {
        return await _context.Orders.FindAsync(id);
    }
    public async Task<Order> CreateOrder(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
    }
    public async Task DeleteOrder(int id) 
    {
        var order = await _context.Orders.FindAsync(id);
        if (order is null)
        {
            return;
        }
        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
    }
}