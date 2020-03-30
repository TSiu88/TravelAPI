using System;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class Country
  {
    public int CountryId {get; set;}
    public string CountryName {get; set;}
    public double CountryRating {get; set;}
    public virtual ICollection<City> Cities{get; set;}
    public Country()
    {
      this.Cities = new HashSet<City>();
    }
  }
    
}