using MediatR;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SaleOrganizer.Application.DTOs;
using AutoMapper;
using SaleOrganizer.Application.Errors;
using System.Net;

namespace SaleOrganizer.Application.Clothes
{
    public class Get
    {
        public class Query : IRequest<List<ClothDto>> { }

        public class Handler : IRequestHandler<Query, List<ClothDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<ClothDto>> Handle(Query request, CancellationToken token)
            {
                var clothes = await _context.Clothes
                    .Include(c => c.Photo)
                    .ToListAsync();

                if(clothes == null)
                    throw new RestException(HttpStatusCode.NotFound, new {
                        clothes = "Not found..."
                    });

                var clothesDto = _mapper.Map<List<Cloth>, List<ClothDto>>(clothes);

                return clothesDto;
            }
        }
    }
}
