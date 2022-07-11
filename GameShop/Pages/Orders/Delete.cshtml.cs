using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Entity;
using GameShop.Models.Service.Interface;

namespace GameShop.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly GameShop.Data.GameShopContext _context;
        private readonly IOrderService _orderService; 

        public DeleteModel(GameShop.Data.GameShopContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        [BindProperty]
      public Models.Entity.Orders Orders { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _orderService.GetOrder(id);

            if (orders == null)
            {
                return NotFound();
            }
            else 
            {
                Orders = orders;
            }

            if (Orders.OrderStatus != OrderStatus.CREATED)
            {
                return RedirectToPage("./Details", new { id = Orders.Id });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }
            var orders = await _orderService.GetOrder(id);

            if (orders != null)
            {
                Orders = orders;
                if (Orders.OrderStatus == OrderStatus.CREATED)
                {
                    await _orderService.DeleteOrder(id);
                }   
            }

            return RedirectToPage("./Details", new { id = Orders.Id });
        }
    }
}
