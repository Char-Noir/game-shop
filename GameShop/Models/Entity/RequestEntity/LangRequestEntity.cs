using GameShop.Models.Utils;
using System.Globalization;

namespace GameShop.Models.Entity.RequestEntity
{
    public class LangRequestEntity:BaseRequestEntity<Lang>
    {
        public string Name => EntityUtils.GetLanguage(new CultureInfo("uk-UA"),Id);
    }
}
