using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GameShop.Data;
using GameShop.Models.Entity;
using Microsoft.AspNetCore.Authorization;
using GameShop.Models.Service.Interface;

namespace GameShop.Pages.Admin.Orders
{
    [Authorize(Roles = "admin,manager")]
    public class DetailsModel : PageModel
    {
        private readonly IOrderService _orderService;
        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public GameShop.Models.Entity.Orders Orders { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(long id)
        {
            if (id == null)
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
            return Page();
        }
    }
}
