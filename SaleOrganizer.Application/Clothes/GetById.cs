using AutoMapper;
using MediatR;
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

namespace SaleOrganizer.Application.Clothes
{
    public class GetById
    {
        public class Query : IRequest<ClothDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ClothDto>
        {
            private DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<ClothDto> Handle(Query request, CancellationToken token)
            {
                var cloth = await _context.Clothes.FindAsync(request.Id);

                if (cloth == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                    {
                        cloth = "Resource Not Found..."
                    });

                var clothDto = _mapper.Map<Cloth, ClothDto>(cloth);

                return clothDto;
            }
        }
    }
}
