using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CountriesController : ControllerBase
  {
    private TravelApiContext _db;

    public CountriesController(TravelApiContext db)
    {
      _db = db;
    }

    // GET api/countries
    [HttpGet]
    public ActionResult<IEnumerable<Country>> Get()
    {
      return _db.Countries.ToList();
    }

    // POST api/countries
    [HttpPost]
    public void Post([FromBody] Country country)
    {
      _db.Countries.Add(country);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Country country)
    {
        country.CountryId = id;
        _db.Entry(country).State = EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var CountryToDelete = _db.Countries.FirstOrDefault(entry => entry.CountryId == id);
      _db.Countries.Remove(CountryToDelete);
      _db.SaveChanges();
    }
  }
}