using OperationsManagementApp.DTOs;
using OperationsManagementApp.Models;

namespace OperationsManagementApp.Services;

public interface IOrderService
{
    Task<Order> CreateOrderAsync(CreateOrderRequest request);
}