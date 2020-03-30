using System;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class City
  {
    public int CityId {get; set;}
    public string CityName {get; set;}
    public double CityRating {get; set;}
    public virtual ICollection<Review> Reviews{get; set;}

    public int CountryId {get; set;}
    public virtual Country Country {get; set;}

    public City()
    {
      this.Reviews = new HashSet<Review>();
    }
  }
    
}