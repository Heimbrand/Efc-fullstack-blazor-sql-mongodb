using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;

namespace Services_labb2_Heimbrand.Client.Services;

public class ProductService : IProductService<ProductDto>
{
    private readonly HttpClient _httpClient;
    public ProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Labb2WebbOlleDb");
    }
    public async Task AddProduct(ProductDto product)
    {
        var response = await _httpClient.PostAsJsonAsync("api/product", product);
       
        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
       
    }
    public async Task DeleteProduct(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/product/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        
    }
    public async Task<IEnumerable<ProductDto>> GetAllProducts()
    {
        var response = await _httpClient.GetAsync("api/product");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<ProductDto>();
        }
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<ProductDto>>();
        return result ?? Enumerable.Empty<ProductDto>();
    }
    public async Task<ProductDto?> GetProductById(int id)
    {
        var response = await _httpClient.GetAsync($"api/product/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
      
        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        return result;
    }
    public async Task<ProductDto?> GetProductByName(string name)
    {
        var response = await _httpClient.GetAsync($"api/product/{name}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
      
        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        return result;
    }
    public async Task UpdateProduct(ProductDto product)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/product/{product.Id}", product);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task UpdateProductDescription(int id, string description)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", description);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task UpdateProductName(int id, string name)
    {
       var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", name);
       if (!response.IsSuccessStatusCode)
       {
            return;
        }
    }
    public async Task UpdateProductPrice(int id, int price)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", price);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task UpdateProductStatus(int id, bool status)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", status);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task UpdateProductStockBalance(int id, int stock)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/product/{id}", stock);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
}