using GameShop.Models.Utils;

namespace GameShop.Models.Entity.RequestEntity
{
    public class ProductsFilterEntity
    {
        public string SearchString { get; init; } = "";
        public double MinPrice { get; init; }
        public double MaxPrice { get; init; } = 10000;
        public bool IsPresent { get; init; } = true;
        public bool IsSkipLang { get; private set; } 
        public bool IsSkipAge { get; private set; } 
        public bool IsSkipCat { get; private set; }
        public CategoryRequestEntity[] Categories { get; }
        public AgeRequestEntity[] Ages { get;  }
        public LangRequestEntity[] Langs { get;  }

        private ProductsFilterEntity(ICollection<Product_Type> types)
        {
            Categories = new CategoryRequestEntity[types.Count];
            var counter = 0;
            foreach (var item in types)
            {
                Categories[counter] = new CategoryRequestEntity(item);
                counter++;
            }
            Ages = new [] {
                new AgeRequestEntity { Id = Age.NEWBORN } ,
                new AgeRequestEntity { Id = Age.CHILD },
                new AgeRequestEntity { Id = Age.KID },
                new AgeRequestEntity { Id = Age.YOUNG },
                new AgeRequestEntity { Id = Age.TEEN },
                new AgeRequestEntity { Id = Age.ADULT }
            };
            Langs = new [] {
                new LangRequestEntity{Id=Lang.UKR},
                new LangRequestEntity{Id=Lang.ENG}
            };
        }

        public ProductsFilterEntity(ICollection<Product_Type> types, IQueryCollection query) : this(types)
        {
            SearchString = QueryUtils.TryGetQueryParam(query, "FilterEntity.SearchString", SearchString);
            MinPrice = QueryUtils.TryGetQueryParam(query, "FilterEntity.Min_price", MinPrice);
            MaxPrice = QueryUtils.TryGetQueryParam(query, "FilterEntity.Max_price", MaxPrice);
            IsPresent = QueryUtils.TryGetQueryParam(query, "FilterEntity.IsPresent", IsPresent);

            var keys = query.Keys;
            var cats = (from item in keys where item.StartsWith("category:") select long.Parse(item.Split(":")[1])).ToList();
            var ages = (from item in keys where item.StartsWith("age:") select item.Split(":")[1]).ToList();
            var langs = (from item in keys where item.StartsWith("lang:") select item.Split(":")[1]).ToList();
            foreach (var item in Categories)
            {
                item.IsChecked = cats.Contains(item.Id) && QueryUtils.TryGetQueryParamCheckBox(query, "category:" + item.Id, item.IsChecked);
            }
            foreach (var item in Ages)
            {
                item.IsChecked = ages.Contains(item.Id.ToString()) && QueryUtils.TryGetQueryParamCheckBox(query, "age:" + item.Id.ToString(), item.IsChecked);
            }
            foreach (var item in Langs)
            {
                item.IsChecked = langs.Contains(item.Id.ToString()) && QueryUtils.TryGetQueryParamCheckBox(query, "lang:" + item.Id.ToString(), item.IsChecked);
            }
        }
        public void Initialize()
        {
            IsSkipAge = EntityUtils.CheckEmptyListRequestEntities(Ages);
            IsSkipLang = EntityUtils.CheckEmptyListRequestEntities(Langs);
            IsSkipCat = EntityUtils.CheckEmptyListRequestEntities(Categories);
        }
    }
}
