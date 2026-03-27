using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsManagementApp.Models;

public class InventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }
    public int Quantity { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal Cost { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}