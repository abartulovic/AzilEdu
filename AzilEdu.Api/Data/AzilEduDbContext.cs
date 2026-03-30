using AzilEdu.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace AzilEdu.Api.Data
{
    public class AzilEduDbContext: DbContext
    {
        public AzilEduDbContext(DbContextOptions<AzilEduDbContext> options)
    : base(options)
        {
        }
        public DbSet<Animal> Animals => Set<Animal>();
        public DbSet<AnimalStatus> AnimalStatuses => Set<AnimalStatus>();

 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.AnimalStatus)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.AnimalStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AnimalStatus>().HasData(
    new AnimalStatus { Id = 1, Name = "Dostupna za udomljenje" },
    new AnimalStatus { Id = 2, Name = "Rezervirana" },
    new AnimalStatus { Id = 3, Name = "Udomljena" },
    new AnimalStatus { Id = 4, Name = "Na liječenju" }
);
            modelBuilder.Entity<Animal>().HasData(
    new Animal
    {
        Id = 1,
        Name = "Luna",
        Species = "Pas",
        Breed = "Mješanac",
        Gender = "Ženka",
        Age = 3,
        ArrivalDate = new DateTime(2025, 1, 15),
        AnimalStatusId = 1,
        ImageUrl = "/images/animals/luna.webp",
        Description = "Mirna i druželjubiva kujica."
    },
    new Animal
    {
        Id = 2,
        Name = "Rex",
        Species = "Pas",
        Breed = "Labrador",
        Gender = "Mužjak",
        Age = 5,
        ArrivalDate = new DateTime(2025, 2, 10),
        AnimalStatusId = 2,
        ImageUrl = "/images/animals/rex.webp",
        Description = "Aktivan pas koji voli šetnje."
    }
);
        }
    }
   }