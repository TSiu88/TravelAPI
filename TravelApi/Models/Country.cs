using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TravelApi.Models
{
  public class Country
  {
    public int CountryId {get; set;}
    [Required]
    public string CountryName {get; set;}
    [JsonIgnore]
    public virtual ICollection<City> Cities{get; set;}
    [JsonIgnore]
    public virtual ICollection<Review> Reviews {get; set;}
    public Country()
    {
      this.Cities = new HashSet<City>();
      this.Reviews = new HashSet<Review>();
    }
  }
}