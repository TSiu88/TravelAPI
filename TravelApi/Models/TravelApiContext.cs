using Microsoft.EntityFrameworkCore;
using System;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public TravelApiContext(DbContextOptions<TravelApiContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Countries {get; set;}
        public DbSet<City> Cities { get; set; }
        public DbSet<Review> Reviews { get; set; }

      protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Country>()
      .HasData(
        new Country { CountryId = 1, CountryName = "Korea"},
        new Country { CountryId = 2, CountryName = "China"},
        new Country { CountryId = 3, CountryName = "Singapore"},
        new Country { CountryId = 4, CountryName = "France"},
        new Country { CountryId = 5, CountryName = "Russia"}
      );

      builder.Entity<City>()
      .HasData(
        new City { CityId = 1, CountryId = 1, CityName = "Seoul", OverallRating = 5},
        new City { CityId = 2, CountryId = 2, CityName = "Shanghai", OverallRating = 5},
        new City { CityId = 3, CountryId = 3, CityName = "Singapore", OverallRating = 3},
        new City { CityId = 4, CountryId = 4, CityName = "Paris", OverallRating = 3.5},
        new City { CityId = 5, CountryId = 5, CityName = "Moscow", OverallRating = 3},
        new City { CityId = 6, CountryId = 2, CityName = "Beijing", OverallRating = 2}
      );
      
      builder.Entity<Review>()
      .HasData(
        new Review { ReviewId = 1, CityId = 1, Title = "Amazing Night Culture", Content = "People are awake until late at night. Drinking is must-do thing", Rating = 5, Date = DateTime.Parse("2/2/2020"), UserName = "Emily"},
        new Review { ReviewId = 2, CityId = 2, Title = "Modern City", Content = "Very modern city with busy but nice people", Rating = 5, Date = DateTime.Parse("2/2/2020"), UserName = "Justin"},
        new Review { ReviewId = 3, CityId = 3, Title = "Most clean country in the world", Content = "Clean and mix of culture", Rating = 3, Date = DateTime.Parse("2/2/2020"), UserName = "Tim"},
        new Review { ReviewId = 4, CityId = 4, Title = "Good Bakeries everywhere!", Content = "In the morning, I can start my day with smell of bakeries in the street.", Rating = 3, Date = DateTime.Parse("2/2/2020"), UserName = "Angela"},
        new Review { ReviewId = 5, CityId = 5, Title = "Very Cold!", Content = "Freezing outside. But it is worth visiting for sure", Rating = 3, Date = DateTime.Parse("2/2/2020"), UserName = "Kim"},
        new Review { ReviewId = 6, CityId = 4, Title = "Museums and the Eiffel Tower", Content = "Really enjoyed seeing the Eiffel Tower and Louve", Rating = 4, Date = DateTime.Parse("2/20/2020"), UserName = "Mari"},
        new Review { ReviewId = 7, CityId = 6, Title = "Forbidden City", Content = "Very large and very crowded", Rating = 2, Date = DateTime.Parse("2/24/2020"), UserName = "Mari"}
      );
    }
        
  }
  
}
