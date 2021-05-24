using System.Threading.Tasks;
using API.Services;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace API.ServicesImpl
{
    public class FileService : IFileService
    {
        public string AddFile(IFormFile file, Cloudinary cloudinary)
        {
            var uploadResult = new RawUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new RawUploadParams
                    {
                        File = new FileDescription(file.Name, stream),
                        PublicId = file.FileName
                    };

                    uploadResult = cloudinary.Upload(uploadParams);
                }
            }

            return uploadResult.Url.ToString();
        }
    }
}