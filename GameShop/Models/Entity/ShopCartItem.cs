namespace GameShop.Models.Entity
{
    //объект корзины/товар в корзине 
    public class ShopCartItem
    {
        public long Id { get; set; } 
        //товар
        public Product Product { get; set; }
        public double Price { get; set; }
        //количество товара
        public int PAmount { get; set; }

        public ShopCartItem(long id, Product product, double price, ShopCart shopCart, int p_amount)
        {
            Id = id;
            Product = product;
            Price = price;
            PAmount = p_amount;
        }

        public ShopCartItem()
        {
        }
    }
}