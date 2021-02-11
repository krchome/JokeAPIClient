using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIConsume.Models;

namespace WebAPIConsume.Controllers
{
    public class JokesController : Controller
    {

        [HttpGet]
        public IActionResult GetRequestURL()
        {
            return View();
        }
        

        [HttpPost]
        public  async Task<IActionResult> GetRequestURL(string newData)
        {
            string receivedData = newData;
            List<Joke> randomJoke = new List<Joke>();

           
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(receivedData))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    randomJoke = JsonConvert.DeserializeObject<List<Joke>>(apiResponse);
                }
            }
            //return View("~/Views/Jokes/GetRequestURL", randomJoke);
            return View(randomJoke);

           
        }
        //[HttpPost]
        //[Route("~/Jokes/GetRequestURL/{categories}")]
        //public IActionResult GetRequestURL(string Categories)
        //{
        //    string[] CategoryList = Categories.Split(',');
        //    return Json(CategoryList);
        //}

        [HttpGet]
        public async Task<string> GetInfo()
        {

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://v2.jokeapi.dev/info?format=txt");
            string apiResponse = await response.Content.ReadAsStringAsync();
            //customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            return apiResponse;

        }
        [HttpGet]
        public async  Task<Joke> GetJokeAdvanced()
        {
            const string baseUrl = "https://v2.jokeapi.dev";
            string[] categories = { "Programming", "Miscellaneous", "Pun", "Spooky", "Christmas" };
            string[] parameters = {
                "blacklistFlags=nsfw,religious,racist",
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
}
