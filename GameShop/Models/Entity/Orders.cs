namespace GameShop.Models.Entity
{
    //заказ
    public class Orders
    {
        public long Id { set; get; }
        public DateTime OrderDate { set; get; }
        public User Customer { set; get; }
        public string ToName { set; get; }
        public string ToTelno { set; get; }
        public string ToEmail { set; get; }
        //адрес доставки и все, дальше не углубляемся, будет время сделаем как разные типы доставки и добавим это
        public string Address { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }
        //статус заказа
        public OrderStatus OrderStatus { set; get; }
        //тип оплаты заказа
        public Payment Payment { set; get; }

        public Orders(long id, DateTime order_date, string to_first_name, string to_last_name, string to_telno, string to_email, string address, List<OrderDetail> orderDetails, OrderStatus orderStatus, Payment payment, User customer)
        {
            Id = id;
            OrderDate = order_date;
            ToName = to_first_name;
            ToTelno = to_telno;
            ToEmail = to_email;
            Address = address;
            OrderDetails = orderDetails;
            OrderStatus = orderStatus;
            Payment = payment;
            Customer = customer;
        }

        public Orders()
        {
        }
    }
}