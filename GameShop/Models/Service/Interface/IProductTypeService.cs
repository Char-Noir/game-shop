using GameShop.Models.Entity;

namespace GameShop.Models.Service.Interface
{
    public interface IProductTypeService
    {
        Task<IList<Product_Type>> GetAll();
    }
}
