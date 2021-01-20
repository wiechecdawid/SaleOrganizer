using MediatR;
using SaleOrganizer.Application.Errors;
using SaleOrganizer.Domain;
using SaleOrganizer.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaleOrganizer.Application.Purchases
{
    public class Create
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public int ClothId { get; set; }
            public Cloth Cloth { get; set; }
            public string ReferenceLink { get; set; }
            public decimal Price { get; set; }
            public TradeType TradeType { get; set; }
            public DeliveryType DeliveryType { get; set; }
            public DateTime PurchaseDate { get; set; }
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
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var cloth = await _context.Clothes.FindAsync(request.ClothId);

                if (cloth == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, new
                    {
                        cloth = "Cloth not found"
                    });

                var purchase = new Purchase
                {
                    Id = request.Id,
                    ClothId = request.ClothId,
                    Cloth = cloth,
                    Price = request.Price,
                    TradeType = request.TradeType,
                    DeliveryType = request.DeliveryType,
                    PurchaseDate = request.PurchaseDate,
                    PaymentDate = request.PaymentDate,
                    DeliveryDate = request.DeliveryDate
                };

                await _context.Purchases.AddAsync(purchase);

                if (await _context.SaveChangesAsync() > 0)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}
