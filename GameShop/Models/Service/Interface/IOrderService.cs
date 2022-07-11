using GameShop.Models.Entity;

namespace GameShop.Models.Service.Interface;

public interface IOrderService
{
    Task<Orders> GetOrder(long id);
    Task<IList<Orders>> GetOrders();
    Task<IList<Orders>> GetOrders(long userId);
    Task<IList<Orders>> GetOrders(long userId, OrderStatus orderStatus);
    Task<IList<Orders>> GetOrders(OrderStatus orderStatus);
    Task<bool> CreateOrder(Orders order);
    Task<bool> UpdateOrder(Orders order);
    Task<bool> DeleteOrder(long id);
    Task<bool> ChangeStatus(Orders orders, OrderStatus orderStatus);
    Task<IList<Orders>> GetFrom(DateTime dateTime);
}