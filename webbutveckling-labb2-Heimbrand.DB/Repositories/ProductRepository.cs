using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB.Repositories;

public class ProductRepository : IProductService<Product>
{
    private readonly WebbHandelDbContext _context;
    public ProductRepository(WebbHandelDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product?> GetProductById(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<Product?> GetProductByName(string name)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Name == name);
    }
    public async Task AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductPrice(int id, int price)
    {
        var originalProduct = await _context.Products.FindAsync(id);
        if (originalProduct is null)
        {
            return;
        }
        originalProduct.Price = price;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductDescription(int id, string description)
    {
        var originalProduct = await _context.Products.FindAsync(id);
        if (originalProduct is null)
        {
            return;
        }
        originalProduct.Description = description;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductStockBalance(int id, int stock)
    {
        var originalProduct = await _context.Products.FindAsync(id);
        if (originalProduct is null)
        {
            return;
        }
        originalProduct.StockBalance = stock;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductStatus(int id, bool status)
    {
        var originalProduct = await _context.Products.FindAsync(id);
        if (originalProduct is null)
        {
            return;
        }
        originalProduct.Status = status;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateProductName(int id, string name)
    {
        var originalProduct = await _context.Products.FindAsync(id);
        if (originalProduct is null)
        {
            return;
        }
        originalProduct.Name = name;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}