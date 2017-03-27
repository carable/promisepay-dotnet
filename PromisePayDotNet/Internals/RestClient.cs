﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PromisePayDotNet.Internals
{

    internal class RestClient : IRestClient
    {
        private HttpClient _client;
        public RestClient()
        {
            _client = new HttpClient();
        }
        public Uri BaseUrl { get => _client.BaseAddress; set => _client.BaseAddress = value; }
        public IAuthenticator Authenticator { get; set; }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            var rel = new Uri(request.url, UriKind.Relative);
            var req = new HttpRequestMessage
            {
                Method = request.Method,
                RequestUri = rel,
            };
            Authenticator?.Add(req);
            
            var result = await _client.SendAsync(req);

            return new RestResponse
            {
                Content = await result.Content.ReadAsStringAsync(),
                ResponseUri = new Uri(BaseUrl, rel),
                StatusCode = result.StatusCode,
                StatusDescription = result.ReasonPhrase
            };
        }
    }
}
