using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal class CatFactFetcher : ICatFactFetcher
    {
        private readonly HttpClient _httpClient;
        string link = "https://catfact.ninja/fact";

        public CatFactFetcher(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //this.link = link;
        }

        public async Task<CatFactResponse> ConnectAsync()
        {
            // Kod do połączenia się z https://catfact.ninja/fact
            var response = await _httpClient.GetFromJsonAsync<CatFactResponse>(link);
            return response;
        }
    }
}
