using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Application.DTOs;
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
        public class Query : IRequest<OfferingDto>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OfferingDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OfferingDto> Handle(Query request, CancellationToken token)
            {
                var offering = await _context.Offerings
                    .Include(o => o.Cloth)
                    .SingleOrDefaultAsync(o => o.Id == request.Id);

                if (offering == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                    {
                        offering = "Resource not found..."
                    });

                var offeringDto = _mapper.Map<Offering, OfferingDto>(offering);

                return offeringDto;
            }
        }
    }
}
