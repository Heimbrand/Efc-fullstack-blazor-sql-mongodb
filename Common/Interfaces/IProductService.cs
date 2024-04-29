namespace Labb2WebbTemplate.Common.Interfaces;

public interface IProductService<T> where T : class
{
    Task<IEnumerable<T>> GetAllProducts();
    Task<T?> GetProductById(int id);
    Task<T?> GetProductByName(string name);
    Task AddProduct(T product);
    Task UpdateProduct(T product);
    Task UpdateProductPrice(int id, int price);
    Task UpdateProductDescription(int id, string description);
    Task UpdateProductStockBalance(int id, int stock);
    Task UpdateProductStatus(int id, bool status);
    Task UpdateProductName(int id, string name);
    Task DeleteProduct(int id);
}