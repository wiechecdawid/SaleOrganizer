using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SaleOrganizer.Application.Interfaces;
using SaleOrganizer.Application.Photos;

namespace SaleOrganizer.Infrastructure.Photos
{
    public class PhotoAccessor : IPhotoAccessor
    {
        public Task<PhotoUploadResult> AddPhoto(IFormFile file)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> DeletePhoto(string publicId)
        {
            throw new System.NotImplementedException();
        }
    }
}