using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace XPRTZ_Binge_watch_api.Models
{
    public class Show
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("premiered")]
        [DataType(DataType.Date)]
        public DateTime Premiered { get; set; }

        [JsonPropertyName("genres")]
        public string Genres { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}
