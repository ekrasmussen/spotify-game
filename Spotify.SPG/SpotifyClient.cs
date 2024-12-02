using Application.SPG.Common.Options;
using Application.SPG.Interfaces;
using Core.Entities;
using Microsoft.Extensions.Options;
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
        private readonly IHttpClientHandler _clientHandler;
        private readonly SpotifyClientOptions _options;
        private SpotifyAccessToken? _accessToken;
        private DateTimeOffset _lastUpdated;
        public SpotifyClient(HttpClient client, IOptions<SpotifyClientOptions> options)
        {
            _clientHandler = new HttpClientHandler(client);
            _options = options.Value;
        }

        public Task<List<Track>> GetTracks(string playlistId)
        {
            throw new NotImplementedException();
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

            _accessToken = JsonSerializer.Deserialize<SpotifyAccessToken>(responseBody);
            _lastUpdated = DateTimeOffset.UtcNow;
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

            return DateTimeOffset.UtcNow >= _lastUpdated.AddSeconds(_accessToken.ExpiresIn);
        }
    }
}
