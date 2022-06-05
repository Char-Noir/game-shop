namespace GameShop.Models.Entity
{
    //тип оплаты: возможен только один тип оплаты на один заказ
    //надо подумать, как реализовать оплату на сайте (заглушку)
    public enum Payment
    {
       CARD,CASH
    }
}