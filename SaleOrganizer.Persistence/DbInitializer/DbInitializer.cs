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
                    var users = new List<AppUser>();

                    if(!context.Users.Any())
                    {
                        users.Add(new AppUser{ UserName="Wiechetek", Email="wiechetek@test.com" });
                    }
                    else
                    {
                        users = context.Users.ToList();
                    }
                    
                    if(!context.Clothes.Any())
                    {
                        var clothes = new List<Cloth>
                        {
                            new Cloth
                            {
                                Id = "test1",
                                Name = "Spodnie",
                                Description = "Niebiekie jeansy z dziurą na kolanie",
                                UserId = users[0].Id
                            },
                            new Cloth
                            {
                                Id = "test2",
                                Name = "Kurtka",
                                Description = "Brązowa skórzana kurtka",
                                UserId = users[0].Id
                            },
                            new Cloth
                            {
                                Id = "test3",
                                Name = "Bluzka",
                                Description = "Biała bluzka w groszki",
                                UserId = users[0].Id
                            },
                            new Cloth
                            {
                                Id = "test4",
                                Name = "Czapka",
                                Description = "Czarna zimowa czapka",
                                UserId = users[0].Id
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
                                Id = Guid.NewGuid().ToString(),
                                ClothId = "test4",
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.allegro,
                                DeliveryType = DeliveryType.ruchPackage,
                                Price = 35.00M,
                                OfferingDate = DateTime.Today.AddHours(5)
                    },
                            new Offering
                            {
                                Id = Guid.NewGuid().ToString(),
                                ClothId = "test3",
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
                                Id = Guid.NewGuid().ToString(),
                                ClothId = "test2",
                                ReferenceLink = "abc.com",
                                TradeType = TradeType.allegro,
                                DeliveryType = DeliveryType.ruchPackage,
                                Price = 25.00M,
                                PurchaseDate = DateTime.Today,
                                PaymentDate = DateTime.Today
                            },
                            new Purchase
                            {
                                Id = Guid.NewGuid().ToString(),
                                ClothId = "test1",
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
