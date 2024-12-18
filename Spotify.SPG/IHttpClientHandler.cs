﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.SPG
{
    public interface IHttpClientHandler
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> GetAsync(string endpoint, HttpMethod method, HttpRequestMessage content);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
