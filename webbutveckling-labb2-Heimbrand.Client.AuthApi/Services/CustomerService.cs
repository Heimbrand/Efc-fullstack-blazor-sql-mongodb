using Labb2WebbTemplate.Common.Dtos;
using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;

namespace webbutveckling;

public class CustomerService : ICustomerService<CustomerDto>
{
    private readonly HttpClient _httpClient;
    public CustomerService(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("Labb2WebbOlleDb");
    }
    public async Task AddCustomer(CustomerDto customer)
    {
        var response = await _httpClient.PostAsJsonAsync("api/customer", customer);
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

    }
    public async Task DeleteCustomer(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/customer/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }
    }

    public async Task<IEnumerable<CustomerDto>> GetAllCustomers()
    {
        var response = await _httpClient.GetAsync("api/customer");
        if (!response.IsSuccessStatusCode)
        {
            return Enumerable.Empty<CustomerDto>();
        }
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerDto>>();
        return result ?? Enumerable.Empty<CustomerDto>();
    }

    public async Task<CustomerDto?> GetCustomerByEmail(string email)
    {
        var response = await _httpClient.GetAsync($"api/customer/email/{email}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
        return result;
    }

    public async Task<CustomerDto?> GetCustomerById(int id)
    {
        var response = await _httpClient.GetAsync($"api/customer/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
        return result;
    }

    public async Task<CustomerDto?> GetCustomerByPhone(string phone)
    {
        var response = await _httpClient.GetAsync($"api/customer/{phone}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
        return result;
    }

    public async Task<CustomerDto> GetOrderProductsByCostumerId(int id)
    {
        var response = await _httpClient.GetAsync($"api/customer/OrderProduct/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
        return result;
    }

    public async Task<CustomerDto> GetProductNameInOrderProductByCustomerId(int id)
    {
        var response = await _httpClient.GetAsync($"api/customer/OrderProduct/ProductName/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadFromJsonAsync<CustomerDto>();
        return result;
    }

    public async Task UpdateCustomer(CustomerDto customer)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{customer.Id}", customer);
    }

    public async Task UpdateCustomerAddress(int id, string address)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/address", address);
    }

    public async Task UpdateCustomerCity(int id, string city)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/city", city);
    }

    public async Task UpdateCustomerCountry(int id, string country)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/country", country);
    }

    public async Task UpdateCustomerEmail(int id, string email)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/email", email);

    }

    public async Task UpdateCustomerFirstName(int id, string name)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/firstname", name);
    }

    public async Task UpdateCustomerLastName(int id, string name)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/lastname", name);
    }

    public async Task UpdateCustomerOrders(int id, ICollection<Order> orders)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/orders", orders);
    }

    public async Task UpdateCustomerPhone(int id, string phone)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/phone", phone);
    }

    public async Task UpdateCustomerZip(int id, string zip)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/customer/{id}/zip", zip);
    }
}