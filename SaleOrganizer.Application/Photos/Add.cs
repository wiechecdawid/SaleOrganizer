using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Application.Interfaces;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;

namespace SaleOrganizer.Application.Photos
{
    public class Add
    {
        public class Command: IRequest<Photo>
        {
            public IFormFile File { get; set; }
            public string ClothId { get; set; }
        }

        public class Handler: IRequestHandler<Command, Photo>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _accessor;
            public Handler(DataContext context, IPhotoAccessor accessor)
            {
                (_context, _accessor) = (context, accessor);
            }

            public async Task<Photo> Handle(Command request, CancellationToken cancellationToken)
            {
                var cloth = await _context.Clothes.FindAsync(request.ClothId);

                if(cloth == null)
                    throw new RestException(System.Net.HttpStatusCode.BadRequest, new
                    {
                        cloth = "Resource not found"
                    });

                if(cloth.Photo != null)
                {
                    string id = cloth.Photo.Id;
                    string result = await _accessor.DeletePhoto(id);

                    if(result == null) throw new Exception("Could not remove previous photo");

                    cloth.Photo = null;
                }

                var photoUploadResult = await _accessor.AddPhoto(request.File);

                if(photoUploadResult == null) throw new Exception("Could not upload file");

                var photo = new Photo
                {
                    Url = photoUploadResult.Url,
                    Id = photoUploadResult.PublicId
                };

                cloth.Photo = photo;

                if(await _context.SaveChangesAsync() > 0)
                    return photo;
                
                throw new Exception("Problem saving changes");
            }
        }
    }
}