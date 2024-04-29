using Labb2WebbTemplate.Common.Entities;
using Labb2WebbTemplate.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace webbutveckling_labb2_Heimbrand.DB.Repositories;

public class CustomerRepository : ICustomerService<Customer>
{
    private readonly WebbHandelDbContext _context;
    public CustomerRepository(WebbHandelDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Customer>> GetAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
    public async Task<Customer?> GetCustomerById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }
    public async Task<Customer> GetOrderProductsByCostumerId(int id)
    {
        return await _context.Customers
            .Include(c => c.Orders)
            .ThenInclude(o => o.Products)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Customer?> GetCustomerByEmail(string email)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);

       
    }
    public async Task<Customer?> GetCustomerByPhone(string phone)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Phone == phone);
    }
    public async Task AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

    }
    public async Task UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerFirstName(int id, string name)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.FirstName = name;
        await _context.SaveChangesAsync();

    }
    public async Task UpdateCustomerLastName(int id, string name)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.LastName = name;
        await _context.SaveChangesAsync();
    } 
    public async Task UpdateCustomerOrders(int id, ICollection<Order> orders)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Orders = orders;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerEmail(int id, string email)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Email = email;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerPhone(int id, string phone)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Phone = phone;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerAddress(int id, string address)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Adress = address;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerCity(int id, string city)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.City = city;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerZip(int id, string zip)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Zip = zip;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateCustomerCountry(int id, string country)
    {
        var originalCustomer = await _context.Customers.FindAsync(id);
        if (originalCustomer is null)
        {
            return;
        }
        originalCustomer.Country = country;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}