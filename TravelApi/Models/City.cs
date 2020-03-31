using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TravelApi.Models
{
  public class City
  {
    public int CityId {get; set;}
    [Required]
    public string CityName {get; set;}
    [JsonIgnore] 
    public virtual ICollection<Review> Reviews{get; set;}
    public double OverallRating {get; set;}
    [Required]
    public int CountryId {get; set;}
    public virtual Country Country {get; set;}

    public City()
    {
      this.Reviews = new HashSet<Review>();
    }

  }
    
}