using Labb2WebbTemplate.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace Labb2WebbTemplate.Common.Dtos;

public class CustomerDto
{
    public int Id { get; set; }
    [Required]
    [StringLength(15, ErrorMessage = "Name length can't be more than 15 characters.")]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]  
    public string Email { get; set; }
    [Phone]
    public string Phone { get; set; }
    [Required]
    public string Adress { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Zip { get; set; }
    [Required]
    public string Country { get; set; }
    public ICollection<Order?> Orders { get; set; }
}