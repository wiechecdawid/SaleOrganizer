﻿using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Clothes
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {
                var cloth = await _context.Clothes.FindAsync(request.Id);
                if(cloth == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new { cloth = "Cannot find resource..." });

                _context.Remove(cloth);

                if (await _context.SaveChangesAsync() > 0)
                    return Unit.Value;

                throw new Exception("Problem with saving data...");
            }
        }
    }
}
