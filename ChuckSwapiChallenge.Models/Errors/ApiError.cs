using System.Text.Json.Serialization;

namespace ChuckSwapiChallenge.Models.Errors
{
    public class ApiError
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
