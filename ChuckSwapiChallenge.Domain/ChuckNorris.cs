using ChuckSwapiChallenge.Contracts.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapiChallenge.Domain
{
    public class ChuckNorris : BaseDomain, IChuckNorris
    {
        public ChuckNorris(IConfiguration config):base(config)
        {
        }
        public async Task<List<string>> JokeCategoriesList()
        {
            var apiUrl = _config.GetSection("ApplicationSettings:ChuckNorrisCategoriesApiUrl").Value;

            var starWarsPeopleList = await GetApiData<List<string>>(apiUrl);
            return starWarsPeopleList;
        }
    }
}
