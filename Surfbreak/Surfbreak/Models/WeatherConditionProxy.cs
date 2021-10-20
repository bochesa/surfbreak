using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Surfbreak.Models
{
    public class WeatherConditionProxy
    {
        private readonly HttpClient client;
        private string _tokenResponse;

        public WeatherConditionProxy(HttpClient client)
        {
            this.client = client;
            getToken();
            //tokenResponse = getToken();
        }

                                        private async Task getToken()
                                        {
                                            var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://identity.surfbreak.dk");
                                            //var discoveryDocument = await client.GetDiscoveryDocumentAsync("http://localhost:61640");
                                            var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                                            new ClientCredentialsTokenRequest
                                            {
                                                Address = discoveryDocument.TokenEndpoint,
                                                ClientId = "client",
                                                ClientSecret = "hest",
                                                Scope = "SurfbreakApi"
                                            });

                                            _tokenResponse = tokenResponse.AccessToken;
                                            //return tokenResponse.AccessToken;
                                        }

        public async Task<string> GetWeatherInfo(string lat, string lon)
        {
            //https://api.surfbreak.dk/WeatherData?lat=55.453&lon=10.7
            client.SetBearerToken(_tokenResponse);
            var response = await client.GetAsync($"{client.BaseAddress}WeatherData/?lat={lat}&lon={lon}");
            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
