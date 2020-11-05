using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ChuckSwapiChallenge.Models
{
    public class ChuckNorrisJokeModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }
    }
}