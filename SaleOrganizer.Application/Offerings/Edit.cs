using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Offerings
{
    public class Edit
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string ClothId { get; set; }
            public string ReferenceLink { get; set; }
            public decimal? Price { get; set; }
            public TradeType? TradeType { get; set; }
            public DeliveryType? DeliveryType { get; set; }
            public DateTime? OfferingDate { get; set; }
            public DateTime? OrderedDate { get; set; }
            public DateTime? SendDate { get; set; }
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
                Cloth cloth = null;

                if (request.ClothId != null)
                    cloth = await _context.Clothes.FindAsync(request.ClothId);

                var offering = await _context.Offerings.FindAsync(request.Id);
                if (offering == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        offering = "Resource not found"
                    });

                offering.ClothId = request.ClothId ?? offering.ClothId;
                offering.Cloth = cloth ?? offering.Cloth;
                offering.ReferenceLink = request.ReferenceLink ?? offering.ReferenceLink;
                offering.Price = request.Price ?? offering.Price;
                offering.TradeType = request.TradeType ?? offering.TradeType;
                offering.DeliveryType = request.DeliveryType ?? offering.DeliveryType;
                offering.OfferingDate = request.OfferingDate ?? offering.OfferingDate;
                offering.OrderedDate = request.OrderedDate ?? offering.OrderedDate;
                offering.SendDate = request.SendDate ?? offering.SendDate;

                if(await _context.SaveChangesAsync() > 0)
                    return Unit.Value;

                throw new Exception("Problem saving changes!");
            }
        }
    }
}
