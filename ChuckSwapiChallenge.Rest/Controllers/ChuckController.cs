using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckSwapiChallenge.Contracts.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiChallenge.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private readonly IChuckNorris _chuckNorris;

        public ChuckController(IChuckNorris chuckNorris)
        {
            _chuckNorris = chuckNorris;
        }
        /// <summary>
        /// Get the chuck norris api joke Categories Available.
        /// </summary>
        /// <returns>Collection of chuck norris joke Categories</returns>
        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<string> categories = await _chuckNorris.JokeCategoriesList();
                return StatusCode(200, categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}