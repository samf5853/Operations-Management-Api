using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;
using OperationsManagementApp.Repositories;

namespace OperationsManagementApp.Services;

public class OrderService : IOrderService
{
    private readonly IInventoryRepository _repository;
    private readonly IOrderRepository _orderRepository;
    
    public OrderService(IInventoryRepository repository, IOrderRepository orderRepository)
    {
        _repository = repository;
        _orderRepository = orderRepository;
    }

    public async Task<Order> CreateOrderAsync(CreateOrderRequest request)
    {
        var ids = request.Items.Select(i => i.InventoryItemId).ToList();

        var inventoryItems = await _repository.GetByIdsAsync(ids);

        // Validate everything BEFORE making any changes
        foreach (var requestItem in request.Items)
        {
            var inventoryItem = inventoryItems
                .FirstOrDefault(i => i.Id == requestItem.InventoryItemId);

            if (inventoryItem == null)
            {
                throw new Exception($"Item with ID {requestItem.InventoryItemId} not found");
            }

            if (requestItem.Quantity <= 0)
            {
                throw new Exception($"Quantity must be greater than zero");
            }

            if (requestItem.Quantity > inventoryItem.Quantity)
            {
                throw new Exception(
                    $"Not enough stock for {inventoryItem.Name}. " +
                    $"Requested: {requestItem.Quantity}, Available: {inventoryItem.Quantity}"
                );
            }
            
        }

        // All validation passed - now build the order
        var order = new Order
        {
            CustomerName = request.CustomerName,
            Status = "Pending",
            OrderDate = DateTime.UtcNow,
            Items = []
        };

        decimal total = 0;

        foreach (var requestItem in request.Items)
        {
            var inventoryItem = inventoryItems
                .First(i => i.Id == requestItem.InventoryItemId);
            
            // Deduct stock
            inventoryItem.Quantity -= requestItem.Quantity;
            
            // Calculate line price
            var linePrice = inventoryItem.Cost * requestItem.Quantity;
            total += linePrice;
            
            order.Items.Add(new OrderItem
            {
                InventoryItemId = requestItem.InventoryItemId,
                Quantity = requestItem.Quantity,
                Price = inventoryItem.Cost //unit price at time of order
            });
        }
        
        order.TotalAmount = total;
        
        await _orderRepository.CreateOrderAsync(order);
        
        return order;
    }
}