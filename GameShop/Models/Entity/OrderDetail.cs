namespace GameShop.Models.Entity
{
    //информация о заказе (состав заказа)
    public class OrderDetail
    {
        public long Id { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Orders Order { get; set; }

        public OrderDetail()
        {
        }

        public OrderDetail(long id, double price, Product product, Orders order)
        {
            Id = id;
            Price = price;
            Product = product;
            Order = order;
        }
    }
}