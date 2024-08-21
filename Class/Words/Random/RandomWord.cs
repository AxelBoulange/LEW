using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace LEW.Class.Words.Random
{
    public class RandomWord
    {
        public static async Task<List<string>> RandomEnglish(int nbWords)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://random-words5.p.rapidapi.com/getMultipleRandom?count=" + nbWords),
                Headers =
                {
                    { "x-rapidapi-key", "874ca9c689msh6fe1f7e6560cbbep185732jsna26cc4476986" },
                    { "x-rapidapi-host", "random-words5.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                List<string> body = await response.Content.ReadFromJsonAsync<List<string>>();
                return body;
            }
        }
    }
}