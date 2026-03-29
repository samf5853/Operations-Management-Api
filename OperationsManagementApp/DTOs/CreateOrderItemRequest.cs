using System.ComponentModel.DataAnnotations;

namespace OperationsManagementApp.DTOs;

public class CreateOrderItemRequest
{
    [Required]
    public int InventoryItemId { get; set; }
    
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
}