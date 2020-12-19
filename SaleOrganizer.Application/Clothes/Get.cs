using MediatR;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SaleOrganizer.Application.Clothes
{
    public class Get
    {
        public class Query : IRequest<List<Cloth>> { }

        public class Handler : IRequestHandler<Query, List<Cloth>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<List<Cloth>> Handle(Query request, CancellationToken token)
            {
                var clothes = await _context.Clothes.ToListAsync();

                return clothes;
            }
        }
    }
}
