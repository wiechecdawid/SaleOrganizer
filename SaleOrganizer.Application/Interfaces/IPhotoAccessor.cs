using System.Threading.Tasks;
using SaleOrganizer.Application.Photos;
using Microsoft.AspNetCore.Http;

namespace SaleOrganizer.Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult> AddPhoto(IFormFile file);
        Task<string> DeletePhoto(string publicId);
    }
}