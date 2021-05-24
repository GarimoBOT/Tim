using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;

namespace API.Services
{
    public interface IFileService
    {
         string AddFile(IFormFile file, Cloudinary cloudinary);
    }
}