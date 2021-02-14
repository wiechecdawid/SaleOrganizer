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

namespace SaleOrganizer.Application.Offerings
{
    public class Get
    {
        public class Query : IRequest<List<OfferingDto>> { }

        public class Handler : IRequestHandler<Query, List<OfferingDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<OfferingDto>> Handle(Query request, CancellationToken token)
            {
                var offerings = await _context.Offerings.Include(o => o.Cloth).ToListAsync();

                var offeringDtos = _mapper.Map<List<Offering>, List<OfferingDto>>(offerings);

                return offeringDtos;
            }
        }
    }
}
