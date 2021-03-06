using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

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

    [HttpGet("popular/byoverallrating")]
    public ActionResult<IEnumerable<City>> GetPopularByRating()
    {
      var query = _db.Cities.Include(entry => entry.Country).OrderByDescending(city => city.OverallRating).AsQueryable();

      return query.ToList();
    }

    // GET api/popular/byreviews
    [HttpGet("popular/byreviews")]
    public ActionResult<IEnumerable<City>> GetPopularByReviews()
    {
      var query = _db.Cities.Include(entry => entry.Country).OrderByDescending(city => city.Reviews.Count).AsQueryable();

      return query.ToList();
    }

    // GET api/random
    [HttpGet("random")]
    public ActionResult<IEnumerable<City>> GetRandom()
    {
      var random = new Random();
      var query = _db.Cities.OrderBy(a => random.Next()).Take(3).ToList();
      return query.ToList();
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