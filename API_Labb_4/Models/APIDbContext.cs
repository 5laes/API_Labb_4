using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_Labb_4.Models
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        public DbSet<Hobbie> Hobbies { get; set; }

        public DbSet<HobbieLink> HobbieLinks { get; set; }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    Id = 1,
                    Name = "Claes",
                    PhoneNumber = "123123123",
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    Id = 2,
                    Name = "Alex",
                    PhoneNumber = "456456456",
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    Id = 3,
                    Name = "Krille",
                    PhoneNumber = "789789789",
                });
            modelBuilder.Entity<Person>().
                HasData(new Person
                {
                    Id = 4,
                    Name = "Linus",
                    PhoneNumber = "147147147",
                });

            modelBuilder.Entity<Hobbie>().
                HasData(new Hobbie
                {
                    Id = 1,
                    HobbieName = "Music",
                    Description = "Making music with sound"
                });
            modelBuilder.Entity<Hobbie>().
                HasData(new Hobbie
                {
                    Id = 2,
                    HobbieName = "Gaming",
                    Description = "Getting that good K/D score"
                });

            modelBuilder.Entity<HobbieLink>().
                HasData(new HobbieLink
                {
                    Id = 1,
                    Link = "Link to drums",
                    PersonId = 1,
                    HobbieId = 1,
                });
            modelBuilder.Entity<HobbieLink>().
                HasData(new HobbieLink
                {
                    Id = 2,
                    Link = "Link to guitars",
                    PersonId = 2,
                    HobbieId = 1,
                });
            modelBuilder.Entity<HobbieLink>().
                HasData(new HobbieLink
                {
                    Id = 3,
                    Link = "Link to Counter Strike",
                    PersonId = 3,
                    HobbieId = 2,
                });
            modelBuilder.Entity<HobbieLink>().
                HasData(new HobbieLink
                {
                    Id = 4,
                    Link = "Link to Farming Simulator",
                    PersonId = 4,
                    HobbieId = 2,
                });
        }
    }
}
