using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FoosballWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly string BaseURL = "http://localhost:4860/";

        public IActionResult Index()
        {
            GetAsyncTeams();

            return View();
        }

        private async void GetAsyncTeams()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var response = await client.GetAsync("api/Managing/GetAllTeams");
            }
        }
    }
}