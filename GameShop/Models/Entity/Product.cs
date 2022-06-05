using System.ComponentModel.DataAnnotations.Schema;

namespace GameShop.Models.Entity
{
    //непосредственно, наша настольная игра
    public sealed class Product:IEquatable<Product>
    {
        public long Id { get; set; }
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }
        //описание игры
        public string ProductDescription { get; set; }
        //продолжительность игры
        public string GameDuration { set; get; }
        //возрастные ограничения
        public int Age { set; get; }
        //количество игроков
        public string NumOfPlayers { set; get; }
        //язык
        public string Localisation { set; get; }
        //комплектация
        public string PackageList { set; get; }
        public string Url { set; get; }
        //ссылка на место хранения изображения
        //зависит от реализации, насколько я понимаю, обрати внимание
        public string ProductImage { get; set; }
        //тип продукта

        public ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();
        public WarhouseItem WarhouseItem { get; set; }
        [NotMapped]
        public List<Product_Type?> _productTypes { get; set; } 
        public string Chars { get; set; }

        public Product(long id, string productName, double productPrice, string productDescription, string gameDuration, int age, string numOfPlayers, string localisation, string packageList, string productImage, string chars)
        {
            Id = id;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductDescription = productDescription;
            GameDuration = gameDuration;
            Age = age;
            NumOfPlayers = numOfPlayers;
            Localisation = localisation;
            PackageList = packageList;
            ProductImage = productImage;
            Chars = chars;
        }

        public Product()
        {
        }

        public bool Equals(Product? other)
        {
            if (other is null)
                return false;
            return Id == other.Id;
        }
        public override bool Equals(object? obj) => Equals(obj as Product);
        public override int GetHashCode() => Id.GetHashCode();

    }
}