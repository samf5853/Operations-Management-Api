using System.ComponentModel.DataAnnotations;

namespace OperationsManagementApp.DTOs;

public class CreateOrderRequest
{
    [Required]
    public string CustomerName { get; set; }
    
    [Required]
    public List<CreateOrderItemRequest> Items { get; set; }
}