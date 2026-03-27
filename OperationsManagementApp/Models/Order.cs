namespace OperationsManagementApp.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public string Status { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public int CreatedBy { get; set; }
    public List<OrderItem> OrderItems { get; set; }
}