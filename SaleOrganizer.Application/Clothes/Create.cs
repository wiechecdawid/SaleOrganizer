using FluentValidation;
using MediatR;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Clothes
{
    public class Create
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public ClothStatus Status { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken token)
            {
                var cloth = new Cloth
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Status = request.Status
                };

                _context.Clothes.Add(cloth);

                var success = await _context.SaveChangesAsync() > 0;

                if (!success)
                    throw new Exception("Problem saving changes...");

                return Unit.Value;
            }
        }
    }
}
