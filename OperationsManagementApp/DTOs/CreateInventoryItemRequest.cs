using System.ComponentModel.DataAnnotations;

namespace OperationsManagementApp.DTOs;

public class CreateInventoryItemRequest
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string SKU { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Range(0, double.MaxValue)]
    public decimal Cost { get; set; }
}