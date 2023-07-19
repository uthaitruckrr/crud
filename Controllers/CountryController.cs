using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var countries = _dbContext.Countries.ToList();
            if(countries == null)
            {
                return NoContent();
            }
            return Ok(countries);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Country> GetById(int id)
        {
            var countries = _dbContext.Countries.Find(id);
            if (countries == null)
            {
                return NoContent();
            }
            return Ok(countries);
        }
        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);

            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult<Country> Update([FromBody] Country country)
        {
            _dbContext.Countries.Update(country);

            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public ActionResult DeleteById(int id)
        {
            var country = _dbContext.Countries.Find(id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}