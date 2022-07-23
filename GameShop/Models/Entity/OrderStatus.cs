namespace GameShop.Models.Entity
{
    //статус заказа: один заказ имеет не более чем один статус
    [Flags]
    public enum OrderStatus
    {
       CREATED = 0b_0000_0000, 
       PAYED = 0b_0000_0001,
       MANAGED = 0b_0000_0010, 
       QUESTIONS = 0b_0000_0100, 
       PACKING = 0b_0000_1000, 
       DELIVERING = 0b_0001_0000, 
       DELIVERED = 0b_0010_0000, 
       CANCELED = 0b_0100_0000
    }
}