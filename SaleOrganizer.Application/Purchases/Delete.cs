using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Purchases
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var purchase = await _context.Purchases.FindAsync(request.Id);

                if (purchase == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        purchase = "Resource not found"
                    });

                _context.Remove(purchase);

                if (await _context.SaveChangesAsync() > 0)
                    return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
