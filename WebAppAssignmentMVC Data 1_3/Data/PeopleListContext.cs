using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppAssignmentMVC_Data_1_3.Models;

namespace WebAppAssignmentMVC_Data_1_3.Data
{
    public class PeopleListContext : DbContext
    {
        public PeopleListContext(DbContextOptions<PeopleListContext> options) : base(options)
        { }

        public DbSet<Person> People { get; set; }


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
            



        }



    }
}
