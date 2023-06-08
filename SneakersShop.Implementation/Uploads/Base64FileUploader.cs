using SneakersShop.Application.Uploads;
using SneakersShop.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Implementation.Uploads
{
    public class Base64FileUploader : IBase64FileUploader
    {
        private List<string> _allowedExtensions = new List<string>()
        {
            "jpg", "png", "jpeg"
        };

        private Dictionary<UploadType, List<string>> _uploadPaths =
            new Dictionary<UploadType, List<string>>
            {
                { UploadType.ProfileImage, new List<string> { "wwwroot", "images", "users" } },
                { UploadType.ProductImage, new List<string> { "wwwroot", "images", "products" } },
            };

        public string GetExtension(string file)
        {
            return file.GetFileExtension();
        }

        public bool IsExtensionValid(string file)
        {
            return _allowedExtensions.Contains(GetExtension(file));
        }

        public string Upload(string file, UploadType type)
        {
            var extension = file.GetFileExtension();

            if (!_allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Unspported file extension.");
            }

            var path = GetPath(type, extension);

            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(file));

            return path;
        }

        private string GetPath(UploadType type, string ext)
        {
            var path = _uploadPaths[type];

            var fileName = "";

            foreach (var pathItem in path)
            {
                fileName = Path.Combine(fileName, pathItem);
            }

            return Path.Combine(fileName, Guid.NewGuid().ToString() + "." + ext);
        }
    }
}
