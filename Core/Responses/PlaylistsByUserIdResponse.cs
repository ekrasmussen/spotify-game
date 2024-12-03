using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Spotify.SPG.Responses
{

    public class PlaylistsByUserIdResponse
    {
        public string Href { get; set; } = string.Empty;
        public int Limit { get; set; }
        public string Next { get; set; } = string.Empty;
        public int Offset { get; set; }
        public string Previous { get; set; } = string.Empty;
        public int Total { get; set; }
        public List<PlaylistResponse> Items { get; set; } = [];
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; } = string.Empty;
    }

    public class Image
    {
        public int? Height { get; set; }
        public string Url { get; set; } = string.Empty;
        public int? Width { get; set; }
    }

    public class PlaylistResponse
    {
        public bool Collaborative { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public List<Image> Images { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        public Owner Owner { get; set; } = new();
        [JsonPropertyName("primary_color")]
        public object PrimaryColor { get; set; } = null!;
        [JsonPropertyName("@public")]
        public bool IsPublic { get; set; }
        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; } = string.Empty;
        [JsonPropertyName("tracks")]
        public Tracks TracksMetaData { get; set; } = new();
        public string Type { get; set; } = string.Empty;
        public string URI { get; set; } = string.Empty;
    }

    public class Owner
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; } = string.Empty;
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string URI { get; set; } = string.Empty;
    }

    public class Tracks
    {
        public string Href { get; set; } = string.Empty;
        public int Total { get; set; }
    }
}
