using System.ComponentModel.DataAnnotations.Schema;

namespace OperationsManagementApp.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int CreatedBy { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    public List<OrderItem> Items { get; set; }
}