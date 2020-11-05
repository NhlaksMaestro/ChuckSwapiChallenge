using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChuckSwapiChallenge.Contracts.Domain;
using ChuckSwapiChallenge.Models.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChuckSwapiChallenge.Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearch _search;

        public SearchController(ISearch search)
        {
            _search = search;
        }
        /// <summary>
        ///Helps the user search through the star wars people and chuck norris jokes external apis.
        /// </summary>
        /// <param name="searchTerm">The text the user inputs to search.</param>
        /// <returns>Returns a Dictionary List containing the url and the list of items found on the url.</returns>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery(Name = "query")] string searchTerm)
        {
            try
            {
                var searchResults = await _search.SearchAllAvailableApis(searchTerm);
                return StatusCode(200, searchResults);
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.Flatten().InnerExceptions)
                {
                    if (e is ApiException)
                    {
                        
                        return StatusCode((int)((ApiException)e)._statusCode, e.Message);
                    }
                }
                return StatusCode(500, ae);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}