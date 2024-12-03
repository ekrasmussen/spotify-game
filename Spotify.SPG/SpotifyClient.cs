using Application.SPG.Common.Interfaces;
using Application.SPG.Common.Options;
using Application.SPG.Interfaces;
using Core.Entities;
using Core.Responses;
using Microsoft.Extensions.Options;
using Spotify.SPG.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spotify.SPG
{
    public class SpotifyClient : ISpotifyClient
    {
        private static readonly JsonSerializerOptions _deserializerOptions = new() { PropertyNameCaseInsensitive = true };
        private readonly IHttpClientHandler _clientHandler;
        private readonly SpotifyClientOptions _options;
        private SpotifyAccessToken? _accessToken;
        private readonly IMasterCache _cache;

        public SpotifyClient(HttpClient client, IOptions<SpotifyClientOptions> options, IMasterCache cache)
        {
            _clientHandler = new HttpClientHandler(client);
            _options = options.Value;
            _cache = cache;
            _accessToken = _cache.GetSpotifyAccessToken();
        }

        public async Task<List<Playlist>> GetPlaylists(string userId)
        {
            await EnsureAccessTokenAsync();


            var endpoint = $"/v1/users/{userId}/playlists?limit=20";
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken!.AccessToken);
            var response = await _clientHandler.GetAsync(endpoint, HttpMethod.Get, request);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<PlaylistsByUserIdResponse>(responseBody, _deserializerOptions);

            List<Playlist> result = [];

            foreach(var playlist in obj!.Items)
            {
                result.Add(new Playlist { ExternalId = playlist.Id, Name = playlist.Name });
            }

            return result;
        }

        public async Task<List<Core.Entities.Track>> GetTracksFromPlaylist(string playlistId)
        {
            await EnsureAccessTokenAsync();

            var endpoint = $"/v1/playlists/{playlistId}/tracks";

            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _accessToken!.AccessToken);
            var response = await _clientHandler.GetAsync(endpoint, HttpMethod.Get, request);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var obj = JsonSerializer.Deserialize<TracksFromPlaylistIdResponse>(responseBody, _deserializerOptions);

            List<Core.Entities.Track> tracks = [];

            foreach(var track in obj!.Items)
            {
                if(track.Track.IsLocal) //In case of local songs, skip
                {
                    continue;
                }

                Core.Entities.Track trackEntry = new Core.Entities.Track
                {
                    ExternalId = track.Track.Id,
                    AlbumName = track.Track.Album.Name,
                    Title = track.Track.Name,
                    IsExplicit = track.Track.Explicit,
                    AddedOn = DateTimeOffset.UtcNow
                };

                string artistsWashed = string.Empty;

                foreach(var artist in track.Track.Artists)
                {
                    artistsWashed += artist.Name + ", ";
                }
                artistsWashed = artistsWashed.TrimEnd(',', ' ');

                trackEntry.ArtistsWashed = artistsWashed;
                tracks.Add(trackEntry);
            }

            return tracks;
        }


        public async Task TestAccessToken()
        {
            await EnsureAccessTokenAsync();
        }

        public async Task RefreshAccessToken()
        {
            var requestBody = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
                { "client_id", _options.ClientId },
                { "client_secret", _options.ClientSecret }
            };

            var content = new FormUrlEncodedContent(requestBody);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await _clientHandler.PostAsync("https://accounts.spotify.com/api/token", content);

            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            _accessToken = JsonSerializer.Deserialize<SpotifyAccessToken>(responseBody, _deserializerOptions);
            _accessToken!.AquiredAt = DateTimeOffset.UtcNow;
            _cache.SetSpotifyAccessToken(_accessToken);
        }

        private async Task EnsureAccessTokenAsync()
        {
            if(_accessToken == null || IsAccessTokenExpired())
            {
                await Console.Out.WriteLineAsync("No access token or its expired, getting new one");
                await RefreshAccessToken();
                await Console.Out.WriteLineAsync("New access token aquired: " + _accessToken!.AccessToken);
            }
        }

        private bool IsAccessTokenExpired()
        {
            if(_accessToken == null )
            {
                return true;
            }

            return DateTimeOffset.UtcNow >= _accessToken.AquiredAt.AddSeconds(_accessToken.ExpiresIn);
        }
    }
}
