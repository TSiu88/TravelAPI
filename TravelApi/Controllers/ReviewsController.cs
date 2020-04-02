using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authorization;

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
    [AllowAnonymous]
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
    [AllowAnonymous]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();  

      City city = _db.Cities.Find(review.CityId);
      double averageRating =  _db.Cities.Where(entry => entry.CityName == city.CityName)
        .Include(entry => entry.Reviews).SelectMany(entry => entry.Reviews).Average(x => x.Rating);
      city.OverallRating = averageRating;
      _db.SaveChanges();  
    }

    [Authorize]
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
      //if(review.UserName.ToLower() == username.ToLower())
      // {
      //if(HttpContext.User.HasClaim(c=> c.Type == ClaimType.Name)
      //{
        review.ReviewId = id;
        _db.Entry(review).State = EntityState.Modified;
        _db.SaveChanges();
        
        City city = _db.Cities.Find(review.CityId);
        double averageRating =  _db.Cities.Where(entry => entry.CityName == city.CityName)
          .Include(entry => entry.Reviews).SelectMany(entry => entry.Reviews).Average(x => x.Rating);
        city.OverallRating = averageRating;
        _db.SaveChanges();  
      //}
        
    }

    [Authorize]
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var ReviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      // if(ReviewToDelete.UserName.ToLower() == username.ToLower())
      // {
        City city = _db.Cities.Find(ReviewToDelete.CityId);
        _db.Reviews.Remove(ReviewToDelete);
        _db.SaveChanges();
        double averageRating =  _db.Cities.Where(entry => entry.CityName == city.CityName)
          .Include(entry => entry.Reviews).SelectMany(entry => entry.Reviews).Average(x => x.Rating);
        city.OverallRating = averageRating;
        _db.SaveChanges();  
      // }
      
    }
  }
}