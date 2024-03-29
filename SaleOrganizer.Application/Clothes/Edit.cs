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
    public class Edit
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string StorageInfo { get; set; }
            public string DetailedStorageInfo { get; set; }
            public ClothStatus? Status { get; set; }
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

                if (cloth == null)
                    throw new RestException(HttpStatusCode.NotFound, new
                    {
                        cloth = "Resource not found..."
                    });

                cloth.Name = request.Name ?? cloth.Name;
                cloth.Description = request.Description ?? cloth.Description;
                cloth.Status = request.Status ?? cloth.Status;
                cloth.StorageInfo = request.StorageInfo ?? cloth.StorageInfo;
                cloth.DetailedStorageInfo = request.DetailedStorageInfo ?? cloth.DetailedStorageInfo;

                var success = await _context.SaveChangesAsync() > 0;

                if(success)
                    return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}
