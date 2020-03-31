using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CitiesController : ControllerBase
  {
    private TravelApiContext _db;

    public CitiesController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/cities
    [HttpGet]
    public ActionResult<IEnumerable<City>> Get(string city, string country)
    {
      var query = _db.Cities.Include(entry => entry.Country).AsQueryable();

      if (city != null)
      {
        query = _db.Cities.Where(entry => entry.CityName == city).Include(entry => entry.Country);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country.CountryName == country);
      }
     
      return query.ToList();
    }

    // GET api/popular/{action}
    [HttpGet("/popular/{action}")]
    public ActionResult<IEnumerable<int>> GetPopular(string action)
    {
      if (action == "byReviews")
      {
        Dictionary<int, int> citiesReviewCount = new Dictionary<int, int> ();
        foreach(City city in _db.Cities)
        {
          citiesReviewCount.Add(city.CityId, city.Reviews.Count());
        }
        citiesReviewCount.OrderBy(reviewCount => reviewCount.Value);
        // return JsonConvert.SerializeObject(citiesReviewCount);
        return citiesReviewCount.Keys.ToList();
        // var query = from n in citiesReviewCount.Select(n.Value);
        // return query.ToList();
      }
      else if (action == "byRating")
      {

      }
      return new List<int> ();
    }


    // POST api/cities
    [HttpPost]
    public void Post([FromBody] City city)
    {
      _db.Cities.Add(city);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] City city)
    {
        city.CityId = id;
        _db.Entry(city).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var CityToDelete = _db.Cities.FirstOrDefault(entry => entry.CityId == id);
      _db.Cities.Remove(CityToDelete);
      _db.SaveChanges();
    }
  }
}