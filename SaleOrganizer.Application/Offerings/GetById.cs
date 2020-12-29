using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Offerings
{
    public class GetById
    {
        public class Query : IRequest<Offering>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Offering>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Offering> Handle(Query request, CancellationToken token)
            {
                var offering = await _context.Offerings.FindAsync(request.Id);

                if (offering == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                    {
                        offering = "Resource not found..."
                    });

                return offering;
            }
        }
    }
}
