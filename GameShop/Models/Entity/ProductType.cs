using System.Collections.Generic;

namespace GameShop.Models.Entity
{
    //тип товара
    //Типы товаров (категории товаров): 
    //семейные, детские, для компании, для двоих,
    //головоломки и пазлы, аксессуары для игр
    public class ProductType
    {
        public long Id { set; get; }

        public Product Product { set; get; }
        public Product_Type? Product_Type { set; get; }

        public ProductType(long id)
        {
            Id = id;
        }

        public ProductType()
        {
        }
    }
}