using Labb2WebbTemplate.Common.Entities;

namespace Labb2WebbTemplate.Common.Interfaces;

public interface ICustomerService<T> where T : class
{
    Task<IEnumerable<T>> GetAllCustomers();
    Task<T?> GetCustomerById(int id);
    Task<T?> GetCustomerByEmail(string email);
    Task<T?> GetCustomerByPhone(string phone);
    Task AddCustomer(T customer);
    Task UpdateCustomer(T customer);
    Task UpdateCustomerFirstName(int id, string name);
    Task UpdateCustomerLastName(int id, string name);
    Task UpdateCustomerOrders(int id, ICollection<Order> orders);
    Task UpdateCustomerEmail(int id, string email);
    Task UpdateCustomerPhone(int id, string phone);
    Task UpdateCustomerAddress(int id, string address);
    Task UpdateCustomerCity(int id, string city);
    Task UpdateCustomerZip(int id, string zip);
    Task UpdateCustomerCountry(int id, string country);
    Task DeleteCustomer(int id);
    Task<T> GetOrderProductsByCostumerId(int id);
}