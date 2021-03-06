﻿using MediatR;
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
        public class Query : IRequest<Cloth>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Cloth>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Cloth> Handle(Query request, CancellationToken token)
            {
                var cloth = await _context.Clothes.FindAsync(request.Id);

                if (cloth == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                    {
                        cloth = "Resource Not Found..."
                    });

                return cloth;
            }
        }
    }
}
