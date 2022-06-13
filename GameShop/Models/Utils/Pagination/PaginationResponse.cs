namespace GameShop.Models.Utils.Pagination;

public class PaginationResponse<T>
{
    public IList<T> Result { get; init; }
    public int Count { get; init;}
    public (double, double) Prices { get; init; } = (0, 10000);
}