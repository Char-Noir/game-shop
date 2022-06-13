﻿using GameShop.Models.Entity;
using GameShop.Models.Entity.RequestEntity;
using System.Globalization;

namespace GameShop.Models.Utils
{
    public static class EntityUtils
    {
        public static string GetAgeRange(Age age)
        {
            switch (age)
            {
                case Age.NEWBORN: return "0 - 3";
                case Age.CHILD: return "3 - 6";
                case Age.KID: return "6 - 12";
                case Age.YOUNG: return "12 - 16";
                case Age.TEEN: return "16 - 18";
                case Age.ADULT: return "18+";
                default: return "0";
            }
        }

        internal static string GetLanguage(CultureInfo cultureInfo, Lang lang)
        {
            if(cultureInfo.ThreeLetterISOLanguageName != "ukr")
            {
                return lang.ToString();
            }
            switch (lang)
            {
                case Lang.UKR: return "Українська";
                case Lang.ENG: return "Англійська";
                default: return lang.ToString();
            }
        }

        public static void InitProductWithCategories(this Product product)
        {
            List<Product_Type?> types = new List<Product_Type?>();
            foreach (var item in product.ProductTypes)
            {
                types.Add(item.Product_Type);
            }
            product._productTypes = types;
        }

        public static void InitPackageList(this Product product)
        {
            product.PackageList = product.PackageList.Replace("\\n", "<br>");
        }

        public static bool CheckEmptyListRequestEntities<T>(BaseRequestEntity<T>[] bases)
        {
            var counter = bases.Count(item => !item.IsChecked);
            return counter == bases.Length;
        }

        public static string GetImage(this Product_Type category)
        {
            switch (category.Name)
            {
                case "Сімейні": return "family.png";
                case "Дитячі": return "child.png";
                case "Для компанії": return "company.png";
                case "Головоломки": return "brain.png";
                case "Для двох": return "two.png";
                case "Карткові": return "kartkovi.png";
                case "Настільні": return "table.png";
                case "Гральні кубики": return "kubiki.png";
                default: throw new ArgumentException("You need to be adult");
            }
            
            
            


        }
    }
}
