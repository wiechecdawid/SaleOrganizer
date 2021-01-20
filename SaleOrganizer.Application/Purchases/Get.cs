using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Purchases
{
    public class Get
    {
        public class Query : IRequest<List<Purchase>> { }

        public class Handler : IRequestHandler<Query, List<Purchase>>
        {
            private DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Purchase>> Handle(Query request, CancellationToken cancellationToken)
            {
                var purchases = await _context.Purchases.ToListAsync();

                return purchases;
            }
        }
    }
}
