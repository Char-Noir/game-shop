﻿using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Utils;
using GameShop.Models.Service.Interface;
using GameShop.Models.Exceptions;
using Microsoft.EntityFrameworkCore;
using GameShop.Models.Utils.Pagination;
using GameShop.Models.Entity.RequestEntity;
using Microsoft.EntityFrameworkCore.Query;

namespace GameShop.Models.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly GameShopContext _context;

        public ProductService(GameShopContext context)
        {
            _context = context;
        }

        public async Task<long> Count()
        {
            return await _context.Product.CountAsync();
        }

        public async Task<IList<Product>> GetPopularProducts(int size)
        {
            return await _context.Product.OrderByDescending(p => _context.Orders.Count(o => o.OrderDetails.Any(d=>d.Product.Id==p.Id)&& o.OrderStatus == ((OrderStatus.DELIVERED | OrderStatus.DELIVERING) & o.OrderStatus))).Take(size).ToListAsync();
        }

        public async Task<IList<Product>> GetNewProducts(int size)
        {
            return await _context.Product.OrderByDescending(p=>p.Id).Take(size).ToListAsync();
        }

        public async Task<IList<Product>> GetBoughtWith(long product,int size)
        {
            var first = await _context.Orders.Where(o => o.OrderDetails.Any(od => od.Product.Id == product)).SelectMany(o=>o.OrderDetails).GroupBy(od=>od.Product.Id).OrderByDescending(od=>od.Count()).Select(od=>od.First().Product).Take(size+1).ToListAsync();
            first.RemoveAll(p => p.Id == product);
            if (first.Count < size)
            {
                first.AddRange(await GetPopularProducts(size-first.Count));
            }

            return first;
        }

        public async Task<IList<Product>> GetByUserAge(User? user, int size)
        {
            if (user == null)
            {
                return await GetPopularProducts(size);
            }
            user.GetAge(_context);
            if (user.Age < 1)
            {
                return await GetPopularProducts(size);
            }

            var users = await _context.MyUser.OrderBy(x => x.BirthDay).ToListAsync();
           

            foreach (var user1 in users)
            {
                user1.GetAge(_context);
            }
            
            users = users.Where(x=>x.Age>=(user.Age-2)&&x.Age<=(user.Age+2)).ToList();
            if (users.Count < 1)
            {
                return await GetPopularProducts(size);
            }
            
            var products = (await _context.Orders.Include(x=>x.Customer).Include(x=>x.OrderDetails).ThenInclude(y=>y.Product).ToListAsync()).Where(x=>users.Any(u=>u.Id==x.Customer.Id)).SelectMany(x=>x.OrderDetails).GroupBy(x=>x.Product).OrderByDescending(x=>x.Count()).Select(x=>x.Key).GroupBy(x=>x.Id).Select(x=>x.FirstOrDefault()).Take(size).ToList();
            var userProd = await _context.Orders.Where(o => o.Customer.Id == user.Id).SelectMany(o => o.OrderDetails).Select(od => od.Product).ToListAsync();
            products.RemoveAll(p=>userProd.Any(x=>x.Id==p.Id));
            if (products.Count < size)
            {
                products.AddRange(await GetPopularProducts(size));
                products = products.GroupBy(x => x.Id).Select(x => x.FirstOrDefault()).Take(size).ToList();
            }

            return products;
        }

        public async Task<bool>  Create(Product product)
        {
            var types = new List<ProductType>();
            foreach (var item in product._productTypes.Where(item => item != null))
            {
                var type = await _context.ProductType.FirstOrDefaultAsync(m => m.Name == item!.Name);
                if (type == null)
                {
                    continue;
                }
                var productType = new ProductType { Product = product, Product_Type = type };
                types.Add(productType);
            }
            if (types.Count == 0)
            {
                throw new ValidationException("Ви повинні обрати хоча б одну категорії!", "NoType");
               
            }
            if (product.WarhouseItem.ProductAmount < 0)
            {
                throw new ValidationException("Кількість наявних ігр повинна бути 0 або більше!", "NoAmount");
                
            }
            product.ProductTypes = types;
            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Product product)
        {
            if (product.Id == 0)
            {
                return false;
            }
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IList<Product>> GetAll()
        {
            return await _context.Product.Include(p=>p.WarhouseItem).ToListAsync();
        }

        public async Task<Product> GetById(long id)
        {
            var product = await _context.Product.Include(p=>p.WarhouseItem).Include(p=>p.ProductTypes).ThenInclude(t=>t.Product_Type).FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                throw new NotFoundException("Товар не був знайдений");
            }
            return product;
        }

        private IQueryable<Product> SimpleFilter(IIncludableQueryable<Product, Product_Type?> query, ProductsFilterEntity filterEntity)
        {
            throw new NotImplementedException();
        }
        
        public async Task<PaginationResponse<Product>> GetPaginatedResult(PaginationDataTable pagination, ProductsFilterEntity filterEntity)
        {
            //Including
            var includes =  _context.Product.Include(p => p.WarhouseItem).Include(p=>p.ProductTypes).ThenInclude(m=>m.Product_Type);
            
            filterEntity.Initialize();
            //Simple filtering
            //By price
            var filters = includes.Where(p => p.ProductPrice >= filterEntity.MinPrice).Where(p => p.ProductPrice <= filterEntity.MaxPrice);
            //By languages
            if (!filterEntity.IsSkipLang)
            {
                filters = filterEntity.Langs.Where(item => !item.IsChecked).Aggregate(filters, (current, item) => current.Where(p => p.Localisation != item.Id.ToString()));
            }
            //By is present in warehouses
            if (filterEntity.IsPresent)
            {
                filters = filters.Where(p => p.WarhouseItem.ProductAmount > 0);
            }
            //By search string
            if (filterEntity.SearchString != string.Empty)
            {
                filters = filters.Where(p => p.ProductName.Contains(filterEntity.SearchString));
            }
            //By ages
            if (!filterEntity.IsSkipAge)
            {
                foreach (var item in filterEntity.Ages)
                {
                    if (item.IsChecked) continue;
                    int max;
                    int min;
                    switch (item.Id)
                    {
                        case Age.NEWBORN:
                        {
                            min = 0;
                            max = 3;
                            break;
                        }
                        case Age.CHILD:
                        {
                            min = 3;
                            max = 6;
                            break;
                        }
                        case Age.KID:
                        {
                            min = 6;
                            max = 12;
                            break;
                        }
                        case Age.YOUNG:
                        {
                            min = 12;
                            max = 16;
                            break;
                        }
                        case Age.TEEN:
                        {
                            min = 16;
                            max = 18;
                            break;
                        }
                        case Age.ADULT:
                        {
                            min = 18;
                            max = 110;
                            break;
                        }
                        default:
                            min = 0;
                            max = 110;
                            break;
                    }
                    filters = filters.Where(p => p.Age > max || p.Age <= min);
                }
            }

            
           
            //Complex filtering
            //TODO:Do it simple
            var promRes = await filters.ToListAsync();
            var sorted = promRes;
            //By categories
            if (!filterEntity.IsSkipCat)
            {
                promRes.ForEach(p => p.InitProductWithCategories());
                sorted = new List<Product>();
                sorted = (from item in filterEntity.Categories where item.IsChecked select promRes.Where(p => p._productTypes.Any(m => m != null && m.Id == item.Id)).ToList()).Aggregate(sorted, (current, newL) => current.Union(newL).ToList());
            }
            var count = sorted.Count; 
            var totalPages = Util.CeilToOne(decimal.Divide(sorted.Count, pagination.PageSize));//if no items in pagination data we still can access to first page
            var prices = (_context.Product.Max(p => p.ProductPrice), _context.Product.Min(p => p.ProductPrice));
            
            if (pagination.CurrentPage > totalPages)
            {
                
                throw new NotFoundException("There are no such page");
            }

            if (pagination.OrderBy == string.Empty)
                return new PaginationResponse<Product>
                {
                    Result = sorted.Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize)
                        .ToList(),
                    Count = count,
                    Prices = prices
                };
            
            if (pagination.Order == Order.ASC)
            {
                sorted = pagination.OrderBy switch
                {
                    "price" => sorted.OrderBy(p => p.ProductPrice).ToList(),
                    "name" => sorted.OrderBy(p => p.ProductName).ToList(),
                    "age" => sorted.OrderBy(p => p.Age).ToList(),
                    _ => sorted.OrderBy(p => p.Id).ToList()
                };
            }
            else
            {
                sorted = pagination.OrderBy switch
                {
                    "price" => sorted.OrderByDescending(p => p.ProductPrice).ToList(),
                    "name" => sorted.OrderByDescending(p => p.ProductName).ToList(),
                    "age" => sorted.OrderByDescending(p => p.Age).ToList(),
                    _ => sorted.OrderByDescending(p => p.Id).ToList()
                };
            }
            
            //Pagination
            return new PaginationResponse<Product>
            {
                Result = sorted.Skip((pagination.CurrentPage - 1) * pagination.PageSize).Take(pagination.PageSize)
                    .ToList(),
                Count = count,
                Prices = prices
            };
        }

        public async Task<bool> Update(Product product)
        {
            _context.Attach(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    throw new NotFoundException("Товар не був знайдений");
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        private bool ProductExists(long id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
