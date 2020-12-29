using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Offerings
{
    public class Get
    {
        public class Query : IRequest<List<Offering>> { }

        public class Handler : IRequestHandler<Query, List<Offering>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Offering>> Handle(Query request, CancellationToken token)
            {
                var offerings = await _context.Offerings.ToListAsync();

                return offerings;
            }
        }
    }
}
