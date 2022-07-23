using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using GameShop.Models.Utils.Pagination;

namespace GameShop.Models.Service.Interface
{
    public interface IProductService
    {
        Task<IList<Product>>  GetAll();
        Task<Product> GetById(long id);
        Task<bool> Create(Product product);
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
        Task<PaginationResponse<Product>> GetPaginatedResult(PaginationDataTable pagination, ProductsFilterEntity filterEntity);
        Task<long> Count();
        
        Task<IList<Product>> GetPopularProducts(int size);
        Task<IList<Product>> GetNewProducts(int size);
        Task<IList<Product>> GetBoughtWith(long product,int size);
        Task<IList<Product>> GetByUserAge(User? user,int size);
    }
}
