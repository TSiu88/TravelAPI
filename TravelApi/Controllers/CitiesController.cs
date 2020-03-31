using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;

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
    public ActionResult<IEnumerable<City>> Get()
    {
      //CAUSES EXCEPTION DUE TO SELF REFERENCING LOOP
      // List<City> cities = _db.Cities.ToList();
      // foreach (City city in cities)
      // {
      //   IQueryable<Country> query = _db.Countries.AsQueryable();
      //   city.Country = query.FirstOrDefault(entry => entry.CountryId == city.CountryId);
      // }
      // cities.foreach(element => {
      //    query = _db.Countries.AsQueryable();
      //    query = query.Where(entry => entry.CountryId == element.CountryId);
      //    element.Country = query;
      // });
      //return cities;
      return _db.Cities.ToList();
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