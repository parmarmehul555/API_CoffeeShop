using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using Web_Api.Data;
using Web_Api.Model;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;
        public CountryController(CountryRepository countryRepository)
        {
            this._countryRepository = countryRepository;
        }
        [HttpGet]
        public IActionResult GetCountry() {
            var Countries = _countryRepository.GetAllCountries();
            return Ok(Countries);
        }

        [HttpPost]
        public IActionResult InsertCountry(CountryModel country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            bool isinserted = _countryRepository.AddCountry(country);
            if (isinserted)
            {
                return Ok();
            }
            return StatusCode(500);
        }

        [HttpPut]
        public IActionResult UpdateCountry(CountryModel country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            bool isinserted = _countryRepository.EditCountry(country);
            if (isinserted)
            {
                return Ok();
            }
            return StatusCode(500);
        }

        [HttpDelete]
        public IActionResult DeleteCountry(int CountryID)
        {

            bool isinserted = _countryRepository.DeleteCountry(CountryID);
            if (isinserted)
            {
                return Ok();
            }
            return StatusCode(500);
        }


        [HttpGet("{id}")]
        public IActionResult GetCityByID(int id)
        {
            var country = _countryRepository.GetCountryByID(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

    }
}
