using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaleOrganizer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleOrganizer.Persistence.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory factory)
        {
            _scopeFactory = factory;
        }
        public async Task Initialize()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<DataContext>())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public async Task Seed()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<DataContext>())
                {
                    if(!context.Clothes.Any())
                    {
                        var clothes = new List<Cloth>
                        {
                            new Cloth
                            {
                                Id = 1,
                                Name = "Spodnie",
                                Description = "Niebiekie jeansy z dziurą na kolanie"
                            },
                            new Cloth
                            {
                                Id = 2,
                                Name = "Kurtka",
                                Description = "Brązowa skórzana kurtka"
                            },
                            new Cloth
                            {
                                Id = 3,
                                Name = "Bluzka",
                                Description = "Biała bluzka w groszki"
                            },
                            new Cloth
                            {
                                Id = 4,
                                Name = "Czapka",
                                Description = "Czarna zimowa czapka"
                            }
                        };

                        await context.Clothes.AddRangeAsync(clothes);
                    }

                    if(!context.Offerings.Any())
                    {
                        var offerings = new List<Offering>
                        {
                            new Offering
                            {
                                Id = 1,
                                ClothId = 1,
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.allegro,
                                DeliveryType = DeliveryType.ruchPackage,
                                Price = 35.00M,
                                OfferingDate = DateTime.Today.AddHours(5)
                    },
                            new Offering
                            {
                                Id = 2,
                                ClothId = 2,
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.vinted,
                                DeliveryType = DeliveryType.inpost,
                                Price = 50.00M,
                                OfferingDate = DateTime.Today
                            }
                        };

                        await context.Offerings.AddRangeAsync(offerings);
                    }

                    if (!context.Purchases.Any())
                    {
                        var purchases = new List<Purchase>
                        {
                            new Purchase
                            {
                                Id = 1,
                                ClothId = 3,
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.allegro,
                                DeliveryType = DeliveryType.ruchPackage,
                                Price = 25.00M,
                                PurchaseDate = DateTime.Today,
                                PaymentDate = DateTime.Today
                            },
                            new Purchase
                            {
                                Id = 2,
                                ClothId = 4,
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.vinted,
                                DeliveryType = DeliveryType.inpost,
                                Price = 40.00M,
                                PurchaseDate = new DateTime(2020, 12, 22)
                            }
                        };

                        await context.Purchases.AddRangeAsync(purchases);
                    }

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
