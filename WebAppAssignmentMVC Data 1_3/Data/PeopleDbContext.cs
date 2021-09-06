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
            .HasName("PrimaryKey_PersonId");

            modelBuilder.Entity<Person>()
                .HasOne(con => con.City)
                .WithMany(cit => cit.People)
                .HasForeignKey(con => con.CityForeignKey);

            modelBuilder.Entity<City>()
                .HasKey(en => en.CityId)
                .HasName("PrimaryKey_CityId");



            modelBuilder.Entity<Country>()
             .HasKey(en => en.CountryId)
             .HasName("PrimaryKey_CountryId");


            /*modelBuilder.Entity<City>()
                .HasOne(con => con.City)
                .WithMany(cit => cit.People)
                .HasForeignKey(con => con.ForeignKey_CountryId);*/



        }



    }
}
