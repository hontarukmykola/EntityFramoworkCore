using EntityFramoworkCore.Entities;
using EntityFramoworkCore.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramoworkCore
{
    public class AirplaneDbContext : DbContext
    {
        public AirplaneDbContext()
        {
            //this.Database.EnsureDeleted();
            // this.Database.EnsureCreated();

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9K9OL7\SQLEXPRESS;Initial Catalog = AirplaneDb2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API Configuration+
            modelBuilder.Entity<Airplane>()
                .Property(a => a.Model)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Client>().ToTable("Passangers");
            modelBuilder.Entity<Client>().Property(c=>c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Client>().Property(c => c.Email)
               .IsRequired()
               .HasMaxLength(100);

            modelBuilder.Entity<Flight>().HasKey(f => f.Id);

            modelBuilder.Entity<Flight>().Property(c=> c.DepartureCity)
                .IsRequired() 
                .HasMaxLength(100);
            modelBuilder.Entity<Flight>().Property(c => c.ArrivalCity)
                .IsRequired()
                .HasMaxLength(100);

            //one to many
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Airplane)
                .WithMany(a => a.Flights)
                .HasForeignKey(a => a.AirplaneId);


            //many to many
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Clients)
                .WithMany(c => c.Flights);

            modelBuilder.SeedAirplanes();
            modelBuilder.SeedFlights();


           
            
        }



    }
}
