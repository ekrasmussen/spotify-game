using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Responses
{
    public class TracksFromPlaylistIdResponse
    {
        public string Href { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = [];
        public int Limit { get; set; }
        public object Next { get; set; } = string.Empty;
        public int Offset { get; set; }
        public object Previous { get; set; } = string.Empty;
        public int Total { get; set; }
    }
    public class AddedBy
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
    }

    public class Album
    {
        [JsonPropertyName("available_markets")]
        public List<string> AvailableMarkets { get; set; } = [];
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("album_type")]
        public string AlbumType { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public List<Image> Images { get; set; } = [];
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; } = string.Empty;
        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
        public List<Artist> Artists { get; set; } = [];
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }
    }

    public class Artist
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }

    public class ExternalIds
    {
        public string Isrc { get; set; } = string.Empty;
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; } = string.Empty;
    }

    public class Image
    {
        public int Height { get; set; }
        public string Urls { get; set; } = string.Empty;
        public int Width { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("added_at")]
        public DateTime AddedAt { get; set; }
        [JsonPropertyName("added_by")]
        public AddedBy AddedBy { get; set; } = new();
        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
        [JsonPropertyName("primary_color")]
        public object PrimaryColor { get; set; } = new();
        public Track Track { get; set; } = new();
        [JsonPropertyName("video_thumbnail")]
        public VideoThumbnail VideoThumbnail { get; set; } = new();
    }

    public class Track
    {
        [JsonPropertyName("preview_url")]
        public object PreviewUrl { get; set; } = new();
        [JsonPropertyName("available_markets")]
        public List<string> AvailableMarkets { get; set; } = [];
        [JsonPropertyName("@explicit")]
        public bool Explicit { get; set; }
        public string Type { get; set; } = string.Empty;
        public bool Episode { get; set; }
        public bool track { get; set; }
        public Album Album { get; set; } = new();
        public List<Artist> Artists { get; set; } = [];
        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }
        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }
        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }
        [JsonPropertyName("external_ids")]
        public ExternalIds ExternalIds { get; set; } = new();
        [JsonPropertyName("external_urls")]
        public ExternalUrls ExternalUrls { get; set; } = new();
        public string Href { get; set; } = string.Empty;
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Popularity { get; set; }
        public string Uri { get; set; } = string.Empty;
        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
    }

    public class VideoThumbnail
    {
        public object Url { get; set; } = string.Empty;
    }
}
