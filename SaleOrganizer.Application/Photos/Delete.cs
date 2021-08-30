using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Application.Interfaces;
using SaleOrganizer.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SaleOrganizer.Application.Photos
{
    public class Delete
    {
        public class Command: IRequest
        {
            public string Id { get; set; }
        }

        public class Handler: IRequestHandler<Command, Unit>
        {
            private readonly IPhotoAccessor _accessor;
            private readonly DataContext _context;

            public Handler(DataContext context, IPhotoAccessor accessor)
            {
                (_context, _accessor) = (context, accessor);
            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {
                var photo = await _context.Photos.FindAsync(request.Id);
                
                var cloth = await _context.Clothes
                    .Include(c => c.Photo)
                    .Where(c => c.Photo.Id == photo.Id)
                    .SingleOrDefaultAsync();

                if(photo == null || cloth == null) throw new RestException(System.Net.HttpStatusCode.NotFound, "one of requested resources not found");

                var result = await _accessor.DeletePhoto(photo.Id);

                if(result == null) throw new RestException(System.Net.HttpStatusCode.ServiceUnavailable, "Could not remove photo from cloudinary.");

                _context.Photos.Remove(photo);

                var success = await _context.SaveChangesAsync();

                if(success > 0) return Unit.Value;

                throw new System.Exception("Problem saving changes");
            }
        }
    }
}