using System.Collections.Generic;

namespace GameShop.Models.Entity
{
    //корзина
    public class ShopCart
    {
        public long ShopCartId { get; set; }
        public User Customer { get; set; }
        //список товаров корзины
        public List<ShopCartItem> ListShopItems { get; set; }
        public bool IsActive { get; set; } = true;

        public ShopCart(long shopCartId, List<ShopCartItem> listShopItems, User customer, bool isActive)
        {
            ShopCartId = shopCartId;
            ListShopItems = listShopItems;
            Customer = customer;
            IsActive = isActive;
        }

        public ShopCart()
        {
            ListShopItems = new List<ShopCartItem>();
        }
    }
}