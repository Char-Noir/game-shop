namespace GameShop.Models.Utils.Pagination
{
    public class PaginationDataTable
    {
        public int CurrentPage { get; init; } = 1;
        public int PageSize { get; init; } = 9;
        public string OrderBy { get; init; } = string.Empty;
        public Order Order { get; init; } = Order.ASC;
    }
}
