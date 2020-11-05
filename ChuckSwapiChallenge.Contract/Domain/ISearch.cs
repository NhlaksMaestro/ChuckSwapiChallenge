using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChuckSwapiChallenge.Contracts.Domain
{
    public interface ISearch
    {
        Task<Dictionary<string, object>> SearchAllAvailableApis(string searchTerm);
    }
}
