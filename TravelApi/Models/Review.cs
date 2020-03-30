using System;

namespace TravelApi.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public double Rating { get; set; }
    public DateTime Date { get; set; }
    public string UserName { get; set; }
    public int CityId {get; set;}
    public virtual City City {get; set;}
  }   
}