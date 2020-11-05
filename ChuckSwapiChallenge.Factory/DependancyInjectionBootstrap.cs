using ChuckSwapiChallenge.Contracts.Domain;
using ChuckSwapiChallenge.Domain;
using ChuckSwapiChallenge.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChuckSwapiChallenge.Factory
{
    public static class DependancyInjectionBootstrap
    {
        //add references alphabetically
        public static void AddDomainDependencies(IServiceCollection services)
        {
            services.AddScoped<IChuckNorris, ChuckNorris>();
            services.AddScoped<IStarWars<StarWarsPeopleModel>, StarWars>();
            services.AddScoped<ISearch, Search>();
        }
    }
}
