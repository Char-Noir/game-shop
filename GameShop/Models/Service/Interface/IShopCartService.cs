using GameShop.Models.Entity;

namespace GameShop.Models.Service.Interface;

public interface IShopCartService
{
    Task AddToCart(Product product, User user, int quantity=1);
    Task RemoveFromCart(Product product, User user);
    Task UpdateQuantity(Product product, User user, int quantity);
    Task ClearCart(User user);
    Task ClearCart(ShopCart shopCart);
    Task<List<ShopCart>> GetShopCarts();
    Task<ShopCart> GetShopCart(long id);
    Task<ShopCart> GetShopCartByUser(User user);
}