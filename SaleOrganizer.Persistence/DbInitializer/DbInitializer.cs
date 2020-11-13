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

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
