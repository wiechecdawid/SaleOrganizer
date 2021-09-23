using FluentValidation;
using MediatR;
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
    public class Create
    {
        public class Command : IRequest
        {
            public string ClothId { get; set; }
            public string ReferenceLink { get; set; }
            public decimal Price { get; set; }
            public TradeType TradeType { get; set; }
            public DeliveryType DeliveryType { get; set; }
            public DateTime? OfferingDate { get; set; }
            public DateTime? OrderedDate { get; set; }
            public DateTime? SendDate { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(o => o.Price).GreaterThanOrEqualTo(0);
                RuleFor(o => o.ReferenceLink).NotEmpty();
            }
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
                var cloth = await _context.Clothes.FindAsync(request.ClothId) ?? throw new RestException(HttpStatusCode.NotFound, new
                {
                    cloth = "Cloth not found"
                });

                var offering = new Offering
                {
                    Id = Guid.NewGuid().ToString(),
                    ClothId = request.ClothId,
                    Cloth = cloth,
                    ReferenceLink = request.ReferenceLink,
                    Price = request.Price,
                    TradeType = request.TradeType,
                    DeliveryType = request.DeliveryType,
                    OfferingDate = request.OfferingDate ?? DateTime.Now,
                    OrderedDate = request.OrderedDate,
                    SendDate = request.SendDate
                };

                await _context.AddAsync(offering);

                var success = await _context.SaveChangesAsync() > 0;

                if (!success)
                    throw new Exception("Problem saving changes...");

                return Unit.Value;
            }
        }
    }
}
