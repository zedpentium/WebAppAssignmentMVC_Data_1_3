using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
            .HasKey(en => en.PersonId)
            .HasName("PrimaryKey_PersonID");

            modelBuilder.Entity<Person>(p =>
            {
                p.Property(en => en.PersonId).IsRequired();
                p.Property(en => en.PersonName).IsRequired();
                p.Property(en => en.PersonPhoneNumber).IsRequired();
                p.Property(en => en.PersonCity).IsRequired();
            });


            modelBuilder.Entity<City>()
            .HasKey(en => en.CityId)
            .HasName("PrimaryKey_CityID");

            modelBuilder.Entity<City>(p =>
            {
                p.Property(en => en.CityId).IsRequired();
                p.Property(en => en.CityName).IsRequired();
            });


            modelBuilder.Entity<Country>()
            .HasKey(en => en.CountryId)
            .HasName("PrimaryKey_CountryID");

            modelBuilder.Entity<Country>(p =>
            {
                p.Property(en => en.CountryId).IsRequired();
                p.Property(en => en.CountryName).IsRequired();
            });


            modelBuilder.Entity<Country>()
                .HasOne(c => c.Country)
                .WithMany<City>(ci => ci.Cities)

                .HasForeignKey(ci => ci.CountryId);

            /*
            modelBuilder.Entity<City>()
                .HasOne(ci => ci.People)
                .WithMany(c => c.Cities)
                .HasForeignKey(ci => ci.CityId);*/


        }



    }
}
