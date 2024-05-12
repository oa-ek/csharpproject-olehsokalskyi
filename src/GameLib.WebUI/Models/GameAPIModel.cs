using GameLib.Core.Entities;
using System.Text.Json.Serialization;

namespace GameLib.WebUI.Models
{
    public class GameAPIResponse
    {

        [JsonPropertyName("results")]
        public List<GameAPIModel> Results { get; set; }
    }

    public class GameAPIModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("released")]
        public DateTime Released { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("background_image")]
        public string Background_image { get; set; }
        [JsonPropertyName("genres")]
        public List<GenreAPIModel> Genres { get; set; }
        [JsonPropertyName("platforms")]
        public List<PlatformAPIModel> Platforms { get; set; }
        [JsonPropertyName("developers")]
        public List<DeveloperAPIModel> Developers { get; set; }
        [JsonPropertyName("publishers")]
        public List<PublisherAPIModel> Publishers { get; set; }


    }
    public class GenreAPIModel
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class PlatformAPIModel
    {
        [JsonPropertyName("platform")]
        public PlatformDetailsAPIModel Platform { get; set; }
    }
    public class PlatformDetailsAPIModel
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class DeveloperAPIModel
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
    public class PublisherAPIModel
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
    public class AchievementsAPIResponse
    {
        [JsonPropertyName("results")]
        public List<AchievementAPIModel> Results { get; set; }
    }
    public class AchievementAPIModel
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }

    }
}
