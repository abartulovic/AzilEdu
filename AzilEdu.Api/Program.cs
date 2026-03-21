using AzilEdu.Api.Data;
using AzilEdu.Shared.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddDbContext<AzilEduDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AzilEduDbContext>();
//    await db.Database.MigrateAsync();

//    if (!await db.Animals.AnyAsync())
//    {
//        db.Animals.AddRange(
//            new Animal
//            {
//                Name = "Luna",
//                Species = "Pas",
//                Breed = "Labrador",
//                Gender = "Žensko",
//                Age = 4,
//                ArrivalDate = new DateTime(2025, 2, 10),
//                IsAdopted = false,
//                ImageUrl = "/images/aziledu/predavanje-5/luna.webp",
//                Description = "Mirna i druželjubiva kujica."
//            },
//            new Animal
//            {
//                Name = "Rex",
//                Species = "Pas",
//                Breed = "Njemaèki ovèar",
//                Gender = "Muško",
//                Age = 6,
//                ArrivalDate = new DateTime(2025, 1, 14),
//                IsAdopted = true,
//                ImageUrl = "/images/aziledu/predavanje-5/rex.webp",
//                Description = "Aktivan i poslušan pas."
//            },
//            new Animal
//            {
//                Name = "Maza",
//                Species = "Maèka",
//                Breed = "Europska kratkodlaka",
//                Gender = "Žensko",
//                Age = 2,
//                ArrivalDate = new DateTime(2025, 3, 2),
//                IsAdopted = false,
//                ImageUrl = "/images/aziledu/predavanje-5/maza.webp",
//                Description = "Umiljata i razigrana maèka."
//            },
//            new Animal
//            {
//                Name = "Boni",
//                Species = "Pas",
//                Breed = "Mješanac",
//                Gender = "Muško",
//                Age = 3,
//                ArrivalDate = new DateTime(2025, 2, 25),
//                IsAdopted = false,
//                ImageUrl = "/images/aziledu/predavanje-5/boni.webp",
//                Description = "Voli šetnje i društvo ljudi."
//            },
//        );

//        await db.SaveChangesAsync();
//    }
//}

app.Run();
