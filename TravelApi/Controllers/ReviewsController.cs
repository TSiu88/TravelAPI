using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;

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
      var query = _db.Reviews.AsQueryable();
      //query.Configuration.LazyLoadingEnabled = false;

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