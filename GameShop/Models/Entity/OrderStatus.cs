namespace GameShop.Models.Entity
{
    //статус заказа: один заказ имеет не более чем один статус
    public enum OrderStatus
    {
       CREATED, PAYED, MANAGED, QUESTIONS, PACKING, DELIVERING, DELIVERED, CANCELED
    }
}