using OperationsManagementApp.Models;

namespace OperationsManagementApp.Repositories;

public interface IOrderRepository
{
    Task<Order> CreateOrderAsync(Order order);
}