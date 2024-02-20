using EntityFramoworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramoworkCore.Helpers
{
    public static class DbInitializer
    {
        public static void SeedAirplanes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>().HasData(new Airplane[]
               {
                 new Airplane()
                {
                    Id = 1,
                    Model = "boing747",
                    MaxPassanger = 300,
                },
                new Airplane()
                {
                    Id = 2,
                    Model = "An914",
                    MaxPassanger = 200,
                },
                 new Airplane()
                {
                    Id = 3,
                    Model = "Mria",
                    MaxPassanger = 150,
                }
               });
        }
        public static void SeedFlights(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasData(new Flight[]
            {
                new Flight()
                {
                    Id = 1,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,2,17),
                    ArrivalTime = new DateTime(2024,2,17),
                    AirplaneId = 1
                },
                 new Flight()
                {
                    Id = 2,
                    DepartureCity = "Warshawa",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,2,18),
                    ArrivalTime = new DateTime(2024,2,18),
                    AirplaneId = 2
                },
                new Flight()
                {
                    Id = 3,
                    DepartureCity = "Kyiv",
                    ArrivalCity = "Lviv",
                    DepartureTime = new DateTime(2024,2,22),
                    ArrivalTime = new DateTime(2024,2,22),
                    AirplaneId = 3
                },


            });
        }
    }
}
