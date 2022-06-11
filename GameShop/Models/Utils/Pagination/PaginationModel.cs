using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameShop.Models.Utils.Pagination
{
    public class PaginationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        [BindProperty(SupportsGet = true)] 
        public string OrderBy { get; set; } = "";
        protected long Count { get; set; }
        protected int PageSize { get; set; } = 9;
        public int TotalPages => Util.CeilToOne(decimal.Divide(Count, PageSize));//if no items in pagination data we still can access to first page
        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
    }
}
