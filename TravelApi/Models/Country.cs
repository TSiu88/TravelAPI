using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Country
  {
    public int CountryId {get; set;}
    [Required]
    public string CountryName {get; set;}
    public virtual ICollection<City> Cities{get; set;}
    public virtual ICollection<Review> Reviews {get; set;}
    public Country()
    {
      this.Cities = new HashSet<City>();
      this.Reviews = new HashSet<Review>();
    }
  }
    
}