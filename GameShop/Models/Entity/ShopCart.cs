using System.Collections.Generic;

namespace GameShop.Models.Entity
{
    //корзина
    public class ShopCart
    {
        public long ShopCartId { get; set; }
        //список товаров корзины
        public List<ShopCartItem> ListShopItems { get; set; }

        public ShopCart(long shopCartId, List<ShopCartItem> listShopItems)
        {
            ShopCartId = shopCartId;
            ListShopItems = listShopItems;
        }

        public ShopCart()
        {
            ListShopItems = new List<ShopCartItem>();
        }
    }
}