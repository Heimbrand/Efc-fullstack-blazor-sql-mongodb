namespace Labb2WebbTemplate.Common.Interfaces;

public interface IOrderService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrders();
    Task<IEnumerable<T>> GetOrdersByCustomerId(int customerId);
    Task<T> GetOrderById(int id);
    Task<T> CreateOrder(T order);
    Task DeleteOrder(int id);
}