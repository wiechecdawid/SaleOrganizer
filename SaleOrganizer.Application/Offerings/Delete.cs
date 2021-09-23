using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;

namespace SaleOrganizer.Application.Offerings
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {
                var offering = await _context.Offerings.FindAsync(request.Id);
                if (offering == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        offering = "Resource not found"
                    });

                _context.Remove(offering);

                if(await _context.SaveChangesAsync() > 0)
                    return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
