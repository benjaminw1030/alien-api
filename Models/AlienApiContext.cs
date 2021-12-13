using Microsoft.EntityFrameworkCore;
using AlienApi.Models;
using System;

namespace AlienApi.Models
{
  public class AlienApiContext : DbContext
  {
    public AlienApiContext(DbContextOptions<AlienApiContext> options)
        : base(options)
    {

    }

    public DbSet<Alien> Aliens { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Alien>().HasData(
        new Alien { AlienId = 1, Name = "Turians", Description = "A warlike lizardlike species", OriginPlanet = "Palaven", OriginSystem = "Palaven", NumberOfPlanets = 123, BreathesOxygen = true, KardashevRating = "1" },
        new Alien { AlienId = 2, Name = "Greys", Description = "A species of short, grey skinned aliens that enjoys experimenting on other lifeforms", OriginPlanet = "Glarikiblak", OriginSystem = "Falzor", NumberOfPlanets = 10, BreathesOxygen = false, KardashevRating = "2" },
        new Alien { AlienId = 3, Name = "Irken", Description = "An Warlike race of alien clones on a galactic Conquest", OriginPlanet = "Irken", OriginSystem = "Kelbo", NumberOfPlanets = 200, BreathesOxygen = true, KardashevRating = "3" },
        new Alien { AlienId = 4, Name = "Tivbots", Description = "A race of sentient Machines created by the Greys", OriginPlanet = "Glarikiblak", OriginSystem = "Falzor", NumberOfPlanets = 14, BreathesOxygen = false, KardashevRating = "2" },
        new Alien { AlienId = 5, Name = "Humans", Description = "A warlike species of hairless monkeys", OriginPlanet = "Earth", OriginSystem = "Sol", NumberOfPlanets = 1, BreathesOxygen = true, KardashevRating = "0" }
      );
    }

  }
}