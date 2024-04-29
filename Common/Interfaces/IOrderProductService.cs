namespace Labb2WebbTemplate.Common.Interfaces;

public interface IOrderProductService<T> where T : class
{
    Task<IEnumerable<T>> GetAllOrderProducts();
    Task AddOrderProduct(T orderProduct);
    Task UpdateOrderProduct(T orderProduct);
}