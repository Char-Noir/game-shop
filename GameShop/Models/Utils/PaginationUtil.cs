namespace GameShop.Models.Utils;

public static class PaginationUtil
{
    public static int[] GetAvaliablePages(int totalPages, int currentPage)
    {
        int[] result;
        if (totalPages < 5)
        {
            result=new int[totalPages];
            for (var i = 0; i < totalPages; i++)
            {
                result[i] = i + 1;
            }
            return result;
        }
        result = new int[5];
        if (currentPage < 3)
        {
            for (var i = 0; i < 5; i++)
            {
                result[i] = i + 1;
            }    
        }
        else if (currentPage > totalPages - 2)
        {
            for (var i = 0; i < 5; i++)
            {
                result[5-1-i] = totalPages - i;
            }  
        }
        else
        {
            for (var i = -2; i < 3; i++)
            {
                result[i + 2] = currentPage + i;
            }
        }
        return result;
    }
}