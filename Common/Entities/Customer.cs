using System.ComponentModel.DataAnnotations;

namespace Labb2WebbTemplate.Common.Entities;

public class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Phone]
    public string? Phone { get; set; }
    public string? Adress { get; set; }
    public string? City { get; set; }
    public string? Zip { get; set; } 
    public string? Country { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}