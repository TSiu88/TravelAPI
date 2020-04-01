using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/reviews
    [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string city, string country)
    {
      var query = _db.Reviews.Include(entry => entry.City).Include(entry => entry.City.Country).AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City.CityName == city);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.City.Country.CountryName == country);
      }
     
      return query.ToList();
    }

    // POST api/reviews
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();  

      City city = _db.Cities.Find(review.CityId);
      //City city = review.City;
      double averageRating =  _db.Cities.Where(entry => entry.CityName == city.CityName)
        .Include(entry => entry.Reviews).SelectMany(entry => entry.Reviews).Average(x => x.Rating);
      city.OverallRating = averageRating;
      _db.SaveChanges();
      // if (review.City.Reviews.Count < 2)
      // {
      //   review.City.OverallRating = review.Rating;
      // }
      // else
      // {
      //   review.City.OverallRating = (review.City.OverallRating + review.Rating)/2;
      // }
      // var selectedCity = _db.Cities.Where(city => city.CityId == review.CityId).Include(city => city.Reviews);
      // //update overall rating here
      // if (selectedCity.Reviews.Count < 2)
      // {
      //   selectedCity.OverallRating = review.Rating;
      // } 
      // else
      // {
      //   selectedCity.OverallRating = (selectedCity.OverallRating + review.Rating) / 2;
      // }
      // _db.Entry(selectedCity).State = EntityState.Modified;
      // _db.SaveChanges();   
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
        review.ReviewId = id;
        _db.Entry(review).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var ReviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      _db.Reviews.Remove(ReviewToDelete);
      _db.SaveChanges();
    }
  }
}