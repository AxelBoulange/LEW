using System.Net.Http.Headers;
using System.Text.Json;

namespace LEW.Resources.Class.API.Words.Translate
{
    public class Translate
    {
        public static async Task<string> EnglishToFrench(string englishWord)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://google-translator9.p.rapidapi.com/v2"),
                Headers =
                {
                    { "x-rapidapi-key", "874ca9c689msh6fe1f7e6560cbbep185732jsna26cc4476986" },
                    { "x-rapidapi-host", "google-translator9.p.rapidapi.com" },
                },
                Content = new StringContent("{\"q\":\""+englishWord+"\",\"source\":\"en\",\"target\":\"fr\",\"format\":\"text\"}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                return JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement.GetProperty("data").GetProperty("translations")[0].GetProperty("translatedText").GetString();
            }
        }
    }
}

