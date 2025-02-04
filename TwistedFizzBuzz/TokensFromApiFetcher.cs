using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace TwistedFizzBuzz
{
    public class TokensFromApiFetcher
    {
        private const string ApiUrl = "https://pie-healthy-swift.glitch.me/word";
        private readonly HttpClient _httpClient;

        public TokensFromApiFetcher()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(2)
            };
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "MyDotNetClient/1.0");

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<(int Divisor, string Token)> FetchOneTokenAsync()
        {
            var apiResponse = await _httpClient.GetAsync(ApiUrl);
            var json = await apiResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ApiResponse>(json);

            if (response == null)
            {
                return (1, "InvalidResponse");
            }

            return (response.number, response.word);
        }


        public async Task<List<(int Divisor, string Token)>> FetchMultipleTokensAsync(int count)
        {
            var result = new List<(int Divisor, string Token)>();
            for (int i = 0; i < count; i++)
            {
                var tokenPair = await FetchOneTokenAsync();
                result.Add(tokenPair);
            }
            return result;
        }

        private class ApiResponse
        {
            public string word { get; set; } = string.Empty;
            public int number { get; set; }
        }
    }
}
