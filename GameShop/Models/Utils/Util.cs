
using UnidecodeSharpFork;

namespace GameShop.Models.Utils
{
    public static class Util
    {
        internal static string GetName(string productName)//need to convert cyrilic into latin and vise versa
        {
            return productName.Unidecode().GenerateSlug();
        }
        internal static int CeilToOne(decimal number)
        {
            var n = (int)Math.Ceiling(number);
            return (n == 0) ? 1 : n;
        }
       internal static string GetFileExtension(string filename)
        {
            return filename[(filename.LastIndexOf('.') + 1)..];
        }

        
    }
}
