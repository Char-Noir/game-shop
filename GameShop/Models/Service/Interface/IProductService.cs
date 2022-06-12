using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using GameShop.Models.Utils.Pagination;

namespace GameShop.Models.Service.Interface
{
    public interface IProductService
    {
        Task<IList<Product>>  GetAll();
        Task<Product> GetById(int id);
        Task<bool> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
        Task<PaginationResponse<Product>> GetPaginatedResult(PaginationDataTable pagination, ProductsFilterEntity filterEntity);
        Task<long> Count();
    }
}
