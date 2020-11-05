using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapiChallenge.Contracts.Domain
{
    public interface IChuckNorris
    {
        Task<List<String>> JokeCategoriesList();
    }
}
