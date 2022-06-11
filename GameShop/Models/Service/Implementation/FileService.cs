using GameShop.Models.Service.Interface;
using GameShop.Models.Utils;

namespace GameShop.Models.Service.Implementation
{
    public class FileService : IFileService
    {

        private readonly IWebHostEnvironment  _environment;

        public FileService(IWebHostEnvironment  environment)
        {
            _environment = environment;
        }

        public async Task Upload(FileType filetype, string name, IFormFile file)
        {
            var folder = filetype switch
            {
                FileType.IMAGE => "images",
                _ => throw new ArgumentOutOfRangeException(nameof(filetype), filetype,
                    "This filetype is not supported yet.")
            };

            var filePath = Path.Combine(_environment.ContentRootPath, "wwwroot", folder, name);
            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
    }
}
