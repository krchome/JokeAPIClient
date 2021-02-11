using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;   // Install with NuGet Package Manager: https://www.nuget.org/packages/Newtonsoft.Json/12.0.3?_src=template

namespace TestHttpRequest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Joke randomJoke = await GetJokeAdvanced();
            if (randomJoke.type == "single")
            {
                Console.WriteLine(randomJoke.joke);
            }
            else
            {
                Console.WriteLine(randomJoke.setup);
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine(randomJoke.delivery);
            }
        }

        public async static Task<Joke> GetJokeAdvanced()
        {
            const string baseUrl = "https://jokeapi.dev";
            string[] categories = { "Programming", "Miscellaneous", "Pun", "Spooky", "Christmas" };
            string[] parameters = {
                "blacklistFlags=nsfw,religious,racist,sexist",
                "idRange=0-100"
            };
            string requestUrl = $"{baseUrl}/joke/{string.Join(",", categories)}?{string.Join("&", parameters)}";
            Joke randomJoke;

            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync(requestUrl);
                randomJoke = JsonConvert.DeserializeObject<Joke>(json);
            }

            return randomJoke;
        }
    }

    public class Joke
    {
        public string type { get; set; }
        public string joke { get; set; }
        public string setup { get; set; }
        public string delivery { get; set; }
        public int id { get; set; }
        public Flags flags { get; set; }
        public bool safe { get; set; }
    }


    public class Flags
    {
        public bool nsfw { get; set; }
        public bool religious { get; set; }
        public bool political { get; set; }
        public bool racist { get; set; }
        public bool sexist { get; set; }
        public bool Explicit { get; set; }
    }
}
