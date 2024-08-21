using System.Net.Http.Headers;

namespace LEW.Class.Words.Random
{

    public class RandomWord
    {
        private const string URL = "https://random-words5.p.rapidapi.com/getMultipleRandom";
        private static string urlParameters = "?count=5";

        public static string RandomEnglish(int nbWords)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

            string test = "";
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                test = response.Content.ReadAsStringAsync().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
            }

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
            return test;
        }
    }
}