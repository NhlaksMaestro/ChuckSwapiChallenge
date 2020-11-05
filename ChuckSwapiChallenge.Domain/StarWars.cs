using ChuckSwapiChallenge.Contracts.Domain;
using ChuckSwapiChallenge.Models;
using ChuckSwapiChallenge.Models.Errors;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace ChuckSwapiChallenge.Domain
{
    public class StarWars : BaseDomain, IStarWars<StarWarsPeopleModel>
    {
        public StarWars(IConfiguration config) : base(config)
        {
        }
        public async Task<ListPaginationModel<StarWarsPeopleModel>> PeopleList()
		{
			var apiUrl = _config.GetSection("ApplicationSettings:StarWarsPeopleApiUrl").Value;

			var starWarsPeopleList = await GetApiData<ListPaginationModel<StarWarsPeopleModel>>(apiUrl);
            return starWarsPeopleList;
        }

    }
}
