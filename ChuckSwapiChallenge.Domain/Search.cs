using ChuckSwapiChallenge.Contracts.Domain;
using ChuckSwapiChallenge.Models;
using ChuckSwapiChallenge.Models.Errors;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChuckSwapiChallenge.Domain
{
    public class Search : BaseDomain, ISearch
    {
        public Search(IConfiguration config) : base(config)
        { }
        private async Task<ListPaginationModel<StarWarsPeopleModel>> SearchStarWarsApi(string searchTerm)
        {
            return await RetrieveDataAndValidate<ListPaginationModel<StarWarsPeopleModel>>(StarWarsSearchUrl(searchTerm));
        }
        private async Task<ListPaginationModel<ChuckNorrisJokeModel>> SearchChuckNorrisApi(string searchTerm)
        {
            return await RetrieveDataAndValidate<ListPaginationModel<ChuckNorrisJokeModel>>(ChuckNorrisSearchUrl(searchTerm));
        }
        private async Task<ListPaginationModel<StarWarsPeopleModel>> InitializeAsyncStarWarsApiSearch(string searchTerm)
        {
            var valToReturn = await SearchStarWarsApi(searchTerm);
            return valToReturn;
        }
        private async Task<ListPaginationModel<ChuckNorrisJokeModel>> InitializeAsyncChuckNorrisApiSearch(string searchTerm)
        {
            var valToReturn = await SearchChuckNorrisApi(searchTerm);
            return valToReturn;
        }
        public async Task<Dictionary<string, object>> SearchAllAvailableApis(string searchTerm)
        {
            return await Task.Run(() =>
            {
                var listToReturn = new Dictionary<string, object>();
                Task[] tasks = { InitializeAsyncStarWarsApiSearch(searchTerm), InitializeAsyncChuckNorrisApiSearch(searchTerm) };
                var tasksList = tasks.ToArray();
                Task.WaitAll(tasksList);
                foreach (var task in tasksList)
                {
                    var taskType = task.GetType().GetProperty("Result").GetValue(task);
                    if (task.IsCompleted)
                    {
                        if (taskType is ListPaginationModel<StarWarsPeopleModel>)
                        {

                            Task<ListPaginationModel<StarWarsPeopleModel>> completedTask = (Task<ListPaginationModel<StarWarsPeopleModel>>)task;
                            listToReturn.Add(StarWarsSearchUrl(searchTerm), completedTask.Result);
                        }
                        if (taskType is ListPaginationModel<ChuckNorrisJokeModel>)
                        {

                            Task<ListPaginationModel<ChuckNorrisJokeModel>> completedTask = (Task<ListPaginationModel<ChuckNorrisJokeModel>>)task;
                            listToReturn.Add(ChuckNorrisSearchUrl(searchTerm), completedTask.Result);
                        }
                    }
                }
                return listToReturn;
            });
        }

        private async Task<T> RetrieveDataAndValidate<T>(string apiUrl)
        {
            var retrievedData = await GetApiData<T>(apiUrl);
            return retrievedData;
        }

        private string StarWarsSearchUrl(string searchTerm)
        {
            return _config.GetSection("ApplicationSettings:StarWarsSearchApiUrl").Value + searchTerm;
        }
        private string ChuckNorrisSearchUrl(string searchTerm)
        {
            return _config.GetSection("ApplicationSettings:ChuckNorrisSearchApiUrl").Value + searchTerm;
        }

    }
}
