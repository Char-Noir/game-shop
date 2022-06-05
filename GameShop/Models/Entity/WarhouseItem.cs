
using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models.Entity
{
    public class WarhouseItem
    {
        [ForeignKey("Product")]
        public long Id { get; set; }
        public virtual Product  Product { get; set; }
        //количество на складе
        public int ProductAmount { get; set; }

    }
}
