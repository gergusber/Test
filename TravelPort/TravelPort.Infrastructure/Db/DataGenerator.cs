using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TravelPort.Domain.Models;

namespace TravelPort.Infrastructure.Db
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TestDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TestDbContext>>()))
            {
                // Look for any board games.
                if (context.People.Any())
                {
                    return;   // Data was already seeded
                }

                context.People.AddRange(
                    new People
                    {
                        Id = 1,
                        Name = "German",
                        Surname = "Bertea",
                        DNI = "123456",
                        Phone = "+34657407036"
                    },
                       new People
                       {
                           Id = 2,
                           Name = "Person",
                           Surname = "Person",
                           DNI = "12313",
                           Phone = "+34657407036"
                       });

                context.SaveChanges();
            }
        }
    }
}