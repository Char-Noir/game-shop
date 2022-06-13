using GameShop.Models.Utils;

namespace GameShop.Models.Entity.RequestEntity
{
    public class AgeRequestEntity:BaseRequestEntity<Age>
    {
        public string Name => EntityUtils.GetAgeRange(Id);
    }
}
