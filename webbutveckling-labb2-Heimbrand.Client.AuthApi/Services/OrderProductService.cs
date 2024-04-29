using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling;

public class OrderProductService : IOrderProductService<OrderProductDto>
{
    private readonly HttpClient _httpClient;
    public OrderProductService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Labb2WebbOlleDb");
    }

    public async Task AddOrderProduct(OrderProductDto orderProduct)
    {
        var response = await _httpClient.PostAsJsonAsync("api/OrderProducts", orderProduct);

        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task<IEnumerable<OrderProductDto>> GetAllOrderProducts()
    {
        var response = await _httpClient.GetAsync("api/OrderProducts");

        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderProductDto>();
        }

        var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderProductDto>>();
        return result ?? Enumerable.Empty<OrderProductDto>();
    }
    public async Task UpdateOrderProduct(OrderProductDto orderProduct)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/OrderProducts/{orderProduct.OrderId}", orderProduct);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
}