using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersShop.Application.Uploads
{
    public enum UploadType
    {
        ProfileImage,
        ProductImage
    }

    public interface IBase64FileUploader
    {
        bool IsExtensionValid(string file);
        string GetExtension(string file);
        string Upload(string file, UploadType type);
    }
}
