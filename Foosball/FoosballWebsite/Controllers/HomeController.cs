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
            return View();
        }
    }
}