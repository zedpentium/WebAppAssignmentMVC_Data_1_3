using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppAssignmentMVC_Data_ER.Models;

namespace WebAppAssignmentMVC_Data_ER.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Setting Primarykeys, instead of [Key] in code. One place to handle all of it /ER
            modelBuilder.Entity<Person>()
                .HasKey(mb => mb.PersonId);
                //.HasName("PrimaryKey_PersonId"); // for reference that i CAN change the name /ER

            modelBuilder.Entity<City>()
                .HasKey(mb => mb.CityId);

            modelBuilder.Entity<Country>()
                .HasKey(mb => mb.CountryId);

            modelBuilder.Entity<Language>()
                .HasKey(mb => mb.LanguageId);

            


            // Setting up One-to-Many
            modelBuilder.Entity<Person>()
                 .HasOne(mbo => mbo.City);

            modelBuilder.Entity<City>()
                 .HasMany(mbm => mbm.People);



            modelBuilder.Entity<City>()
                .HasOne(mbo => mbo.Country);

            modelBuilder.Entity<Country>()
                .HasMany(mbm => mbm.Cities);


            /*modelBuilder.Entity<Person>()
                 .HasMany(p => p.Languages);

            modelBuilder.Entity<Language>()
                 .HasMany(la => la.People);*/



            // Setting up the join-table for the mutual many-to-many bind/relationship
            modelBuilder.Entity<PersonLanguage>()  // EF Core 3.x specific. Join table /ER
                .HasKey(pl => new { pl.PersonId, pl.LanguageId });

            modelBuilder.Entity<PersonLanguage>() // One Person to Many Languages
                .HasOne(ec => ec.Person)
                .WithMany(e => e.PersonLanguages)
                .HasForeignKey(ec => ec.PersonId);

            modelBuilder.Entity<PersonLanguage>()  // One Language to Many People
                .HasOne(ec => ec.Language)
                .WithMany(c => c.PersonLanguages)
                .HasForeignKey(ec => ec.LanguageId);

        }



    }
}
