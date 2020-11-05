using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ChuckSwapiChallenge.Models
{
    public class StarWarsPeopleModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("mass")]
        public string Mass { get; set; }
        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }
        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        [JsonPropertyName("home_world")]
        public string HomeWorld { get; set; }
        [JsonPropertyName("films")]
        public string[] Films { get; set; }
        [JsonPropertyName("species")]
        public string[] Species { get; set; }
        [JsonPropertyName("vehicles")]
        public string[] Vehicles { get; set; }
        [JsonPropertyName("starships")]
        public string[] Starships { get; set; }
        [JsonPropertyName("created")]
        public DateTime Created { get; set; }
        [JsonPropertyName("edited")]
        public DateTime Edited { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
