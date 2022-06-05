

using Microsoft.EntityFrameworkCore;

namespace GameShop.Models.Entity
{
    public class Product_Type
    {
        public long Id { set; get; }
        public string Name { set; get; }

        public Product_Type(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product_Type()
        {
        }
    }
}
