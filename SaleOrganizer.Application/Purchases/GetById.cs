using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Application.DTOs;
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
        public class Query : IRequest<PurchaseDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, PurchaseDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<PurchaseDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var purchase = await _context.Purchases
                                        .Include(p => p.Cloth)
                                        .SingleOrDefaultAsync(p => p.Id == request.Id);

                if (purchase == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        purchase = "Resource not found"
                    });

                var purchaseDto = _mapper.Map<Purchase, PurchaseDto>(purchase);

                return purchaseDto;
            }
        }
    }
}
