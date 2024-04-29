using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Interfaces;

namespace Services_labb2_Heimbrand.Client.Services;

public class OrderService : IOrderService<OrderDto>
{
    private readonly HttpClient _httpClient;
    public OrderService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Labb2WebbOlleDb");
    }
    public async Task<OrderDto> CreateOrder(OrderDto order)
    {
        var response = await _httpClient.PostAsJsonAsync("api/order", order);
      
        var result = await response.Content.ReadFromJsonAsync<OrderDto>();
        return result;
    }
    public async Task DeleteOrder(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/order/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }
    public async Task<IEnumerable<OrderDto>> GetAllOrders()
    {
        var response = await _httpClient.GetAsync("api/order");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderDto>();
        }
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDto>>();
        return result ?? Enumerable.Empty<OrderDto>();
    }
    public async Task<OrderDto> GetOrderById(int id)
    {
       var response = await _httpClient.GetAsync($"api/order/{id}");
      
        var result = await response.Content.ReadFromJsonAsync<OrderDto>();
        return result;
    }
    public async Task<IEnumerable<OrderDto>> GetOrdersByCustomerId(int customerId)
    {
        var response = await _httpClient.GetAsync($"api/order/customer/{customerId}");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<OrderDto>();
        }
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<OrderDto>>();
        return result ?? Enumerable.Empty<OrderDto>();
    }
}