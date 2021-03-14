using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Application.DTOs;
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
        public class Query : IRequest<List<PurchaseDto>> { }

        public class Handler : IRequestHandler<Query, List<PurchaseDto>>
        {
            private DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<PurchaseDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var purchases = await _context.Purchases.Include(p => p.Cloth).ToListAsync();

                var purchaseDtos = _mapper.Map<List<Purchase>, List<PurchaseDto>>(purchases);

                return purchaseDtos;
            }
        }
    }
}
