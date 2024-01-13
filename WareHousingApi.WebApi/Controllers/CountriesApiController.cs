using Microsoft.AspNetCore.Mvc;
using WareHousingApi.DataModel.Entities;
using WareHousingApi.DataModel.Services.Interface;

namespace WareHousingApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesApiController : ControllerBase
    {
        private readonly IUnitOfWork _context;
        public CountriesApiController(IUnitOfWork context)
        {
            _context = context;
        }
        [HttpGet("GetCountry")]
        public IEnumerable<Country> Get()
        {
            var contryget = _context.countryUW.Get();
            return contryget;
        }

        [HttpGet("GetById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Country),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int countryId)
        {
            var country = _context.countryUW.GetById(countryId);
            return country == null? NotFound() : Ok(country);
        }
        [HttpPost]
        [Route("CreateCountryApi")]
        public IActionResult Create([FromForm] string countryName = "")
        {
            if (countryName == "") return BadRequest(ModelState);
            var getCountry = _context.countryUW.Get(c => c.CountryName == countryName);
            if (getCountry.Count() > 0)
            {
                return StatusCode(550);
            }
            try
            {
                Country C = new Country
                {
                    CountryName = countryName,
                };
                _context.countryUW.Create(C);
                _context.Save();
                return Ok(C);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [Route("UpdateCountry")]
        [ProducesResponseType(typeof(Country), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Country model)
        {
            if (model.CountryId == 0) return BadRequest();
            _context.countryUW.Update(model);
            _context.Save();
            return Ok(model);
        }
    }
}
