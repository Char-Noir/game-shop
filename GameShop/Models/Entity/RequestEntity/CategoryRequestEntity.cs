namespace GameShop.Models.Entity.RequestEntity
{
    public class CategoryRequestEntity : BaseRequestEntity<long>
    {


        public CategoryRequestEntity(Product_Type item) : base(item.Id, true)
        {
            Name = item.Name;
        }

        public string Name { get; init; }
    }
}