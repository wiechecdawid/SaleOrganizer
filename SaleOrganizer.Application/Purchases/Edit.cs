using MediatR;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Purchases
{
    public class Edit
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string ClothId { get; set; }
            public Cloth Cloth { get; set; }
            public string ReferenceLink { get; set; }
            public decimal? Price { get; set; }
            public TradeType? TradeType { get; set; }
            public DeliveryType? DeliveryType { get; set; }
            public DateTime? PurchaseDate { get; set; }
            public DateTime? PaymentDate { get; set; }
            public DateTime? DeliveryDate { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }
            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
