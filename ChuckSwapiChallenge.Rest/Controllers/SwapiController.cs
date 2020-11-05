using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckSwapiChallenge.Contracts.Domain;
using ChuckSwapiChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiChallenge.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly IStarWars<StarWarsPeopleModel> _starWars;

        public SwapiController(IStarWars<StarWarsPeopleModel> starWars)
        {
            _starWars = starWars;
        }
        /// <summary>
        /// Get the star wars people model.
        /// </summary>
        /// <returns>Paginated Collection of star wars people api model endpoint.</returns>
        [HttpGet("people")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var starWarsPeopleList = await _starWars.PeopleList();
                return StatusCode(500, starWarsPeopleList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}