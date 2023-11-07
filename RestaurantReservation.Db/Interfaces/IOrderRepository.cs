﻿using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task UpdateOrderAsync(Order order);
        Task<double> CalculateAverageOrderAmountAsync(int employeeId);
    }
}
