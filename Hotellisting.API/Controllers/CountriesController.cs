using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotellisting.API.Data;
using Hotellisting.API.Data.Models;
using Hotellisting.API.DTOs;
using AutoMapper;
using Hotellisting.API.DTOs.Country;
using Hotellisting.API.Repository;
using Hotellisting.API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace Hotellisting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(IMapper mapper, ICountryRepository countryRepository)
        {
            this._mapper = mapper;
            this._countryRepository = countryRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountryDTO>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countryRepository.GetDetails(id);
           

            if (country == null)
            {
                return NotFound();
            }

            var countryDTO = _mapper.Map<CountryDTO>(country);
            return Ok(countryDTO);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDTO updateCountryDTO)
        {
            if (id != updateCountryDTO.Id)
            {
                return BadRequest();
            }

            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDTO, country);

            try
            {
                await _countryRepository.UpdateAsync(country);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _countryRepository.AddAsync(country);
         
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countryRepository.Exists(id);
        }
    }
}
