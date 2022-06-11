using GameShop.Models.Utils;

namespace GameShop.Models.Service.Interface
{
    public interface IFileService
    {
        Task Upload(FileType filetype, string name, IFormFile file);
    }
}
