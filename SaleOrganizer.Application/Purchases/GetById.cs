using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Purchases
{
    public class GetById
    {
        public class Query : IRequest<Purchase>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Purchase>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Purchase> Handle(Query request, CancellationToken cancellationToken)
            {
                var purchase = await _context.Purchases.FindAsync(request.Id);

                if (purchase == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        purchase = "Resource not found"
                    });

                return purchase;
            }
        }
    }
}
