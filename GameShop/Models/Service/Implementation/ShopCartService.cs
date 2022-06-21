using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Exceptions;
using GameShop.Models.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Models.Service.Implementation;

public class ShopCartService:IShopCartService
{
    private readonly GameShopContext _context;

    public ShopCartService(GameShopContext context)
    {
        _context = context;
    }


    public async Task AddToCart(Product product, User user, int quantity=1)
    {
        Product? product1 = await _context.Product.Include(x => x.WarhouseItem).FirstOrDefaultAsync(x => x.Id == product.Id);
        if(product1 == null)
        {
            throw new NotFoundException("Product not found!");
        }
        var cart = await GetShopCartByUser(user);
        var cartItem = cart.ListShopItems.FirstOrDefault(item => item.Product.Id == product1.Id);
        if (quantity <= 0 || quantity > product1.WarhouseItem.ProductAmount)
        {
            throw new InvalidDataException("Invalid quantity");
        }
        if (cartItem == null)
        {
            cartItem = new ShopCartItem
            {
                Product = product,
                PAmount = quantity,
                Price = -1
            };
            cart.ListShopItems.Add(cartItem);
        }
        else
        {
            cartItem.PAmount += quantity;
        }
        await _context.SaveChangesAsync();
    }

    public async Task RemoveFromCart(Product product, User user)
    {
        var cart = await GetShopCartByUser(user);
        var cartItem = cart.ListShopItems.FirstOrDefault(item => item.Product.Id == product.Id);
        if (cartItem == null)
        {
            throw new NotFoundException("Product not found in cart");
        }
        cart.ListShopItems.Remove(cartItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateQuantity(Product product, User user, int quantity)
    {
        Product? product1 = await _context.Product.Include(x => x.WarhouseItem).FirstOrDefaultAsync(x => x.Id == product.Id);
        if (product1 == null)
        {
            throw new NotFoundException("Product not found!");
        }
        var cart = await GetShopCartByUser(user);
        var cartItem = cart.ListShopItems.FirstOrDefault(item => item.Product.Id == product1.Id);
        if (cartItem==null)
        {
            throw new NotFoundException("Product not found in cart");
        }

        if (quantity <= 0 || quantity > product1.WarhouseItem.ProductAmount)
        {
            throw new InvalidDataException("Invalid quantity");
        }
       
        cartItem.PAmount = quantity;
        await _context.SaveChangesAsync();
    }

    public async Task ClearCart(User user)
    {
        var cart = await GetShopCartByUser(user);
        cart.ListShopItems = new List<ShopCartItem>();
        await _context.SaveChangesAsync();
    }

    public async Task ClearCart(ShopCart shopCart)
    {
        var cart = await GetShopCart(shopCart.ShopCartId);
        cart.ListShopItems = new List<ShopCartItem>();
        await _context.SaveChangesAsync();
    }


    public async Task<List<ShopCart>> GetShopCarts()
    {
        return await _context.ShopCart.Where(x=>x.IsActive).ToListAsync();
    }

    public async Task<ShopCart> GetShopCart(long id)
    {
        var shopCart = await _context.ShopCart.FirstOrDefaultAsync(x => x.ShopCartId == id && x.IsActive);
        if (shopCart == null)
        {
            throw new NotFoundException("ShopCart with this id not found");
        }
        return shopCart;
    }

    public async Task<ShopCart> GetShopCartByUser(User user)
    {
        var shopCart = await _context.ShopCart.Include(x => x.ListShopItems).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Customer == user && x.IsActive);
        if (shopCart == null)
        {
          shopCart =  new ShopCart()
            {
                Customer = user,
                ListShopItems = new List<ShopCartItem>()
            };
            _context.ShopCart.Add(shopCart);
        }
        return shopCart;
    }
    
}