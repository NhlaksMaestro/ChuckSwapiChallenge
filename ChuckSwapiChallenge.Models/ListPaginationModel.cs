using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace ChuckSwapiChallenge.Models
{
    public class ListPaginationModel<T>
    {
        [JsonPropertyName("count")]
        public int? Count { get; set; }
        [JsonPropertyName("total")]
        public int? Total { get; set; }
        [JsonPropertyName("previous")]
        public string Previous { get; set; }
        [JsonPropertyName("next")]
        public string Next { get; set; }
        [JsonPropertyName("results")]
        public List<T> Results { get; set; }
        public bool ShouldSerializeResultsList()
        {
            return (Results.Count > 0);
        }
        [JsonPropertyName("result")]
        public List<T> Result { get; set; }
        public bool ShouldSerializeResultList()
        {
            return (Result.Count > 0);
        }
    }
}
