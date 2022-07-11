using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Exceptions;
using GameShop.Models.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Models.Service.Implementation;

public class OrderService : IOrderService
{
    private readonly GameShopContext _context;

    public OrderService(GameShopContext context)
    {
        _context = context;
    }

    public async Task<Orders> GetOrder(long id)
    {
        return await _context?.Orders?.Include(o=>o.OrderDetails).ThenInclude(d=>d.Product).FirstOrDefaultAsync(o=> o.Id == id)!?? throw new NotFoundException("There are no orders with this id");
    }

    public async Task<IList<Orders>> GetOrders()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<IList<Orders>> GetOrders(long userId)
    {
        return await _context.Orders.Include(o=>o.Customer).Where(o=> o.Customer.Id== userId).ToListAsync();
    }

    public async Task<IList<Orders>> GetOrders(long userId, OrderStatus orderStatus)
    {
        return await _context.Orders.Include(o=>o.Customer).Where(o=> o.Customer.Id== userId && o.OrderStatus==orderStatus).ToListAsync();
    }

    public async Task<IList<Orders>> GetOrders(OrderStatus orderStatus)
    {
        return await _context.Orders.Where(o=>o.OrderStatus==orderStatus).ToListAsync();
    }

    public async Task<bool> CreateOrder(Orders order)
    {
        if ((from item in order.OrderDetails let product = _context.Product.Include(p => p.WarhouseItem).FirstOrDefault(p => p.Id == item.Product.Id) where product != null && (item.Quantity < 0 || item.Quantity > product.WarhouseItem.ProductAmount) select item).Any())
        {
            throw new Exception("There are not enough products in the warehouse");
        }
        
        foreach (var item in order.OrderDetails)
        {
            var product = _context.Product.Include(p => p.WarhouseItem).FirstOrDefault(p => p.Id == item.Product.Id);
            if (product != null) product.WarhouseItem.ProductAmount -= item.Quantity;
        }
        
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateOrder(Orders order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteOrder(long id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o=>o.Id==id);
        if (order == null)
        {
            throw new NotFoundException("There are no orders with this id");
        }
        order.OrderStatus= OrderStatus.CANCELED;
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ChangeStatus(Orders orders, OrderStatus orderStatus)
    {
        orders.OrderStatus = orderStatus;
        _context.Orders.Update(orders);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IList<Orders>> GetFrom(DateTime dateTime)
    {
        return await _context.Orders.Where(o => o.OrderDate>=dateTime).ToListAsync();
    }
}