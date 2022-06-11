using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Models.Service.Implementation
{
    public class ProductTypeService:IProductTypeService
    {
        private readonly GameShopContext _context;

        public ProductTypeService(GameShopContext context)
        {
            _context = context;
        }

        public async Task<IList<Product_Type>> GetAll()
        {
           return await _context.ProductType.ToListAsync();
        }
    }
}
