using System;
using System.ComponentModel.DataAnnotations;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    public double Rating { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [Required]
    public string UserName { get; set; }
    public int CityId {get; set;}
    public virtual City City {get; set;}

    // public Review(int cityId)
    // {
      

    // }
  }

}