using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using segfy.youtube.frontend.Models;

namespace segfy.youtube.frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _apiUrl;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _apiUrl = config.GetValue(typeof(string), "ApiUrl").ToString();
        }

        public async Task<IActionResult> IndexAsync()
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var log = await response.Content.ReadAsAsync<List<SearchTerm>>();
                return View(log);
            }
            return View(new List<SearchTerm>());
        }

        [HttpPost("Details")]
        public async Task<IActionResult> DetailsAsync(string term)
        {
            using var client = new HttpClient();
            var searchObject = new { Term = term };
            var jsonTerm = JsonConvert.SerializeObject(searchObject);
            var content = new StringContent(jsonTerm, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(_apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                var searchTerm = await response.Content.ReadAsAsync<SearchTerm>();
                return View(searchTerm);
            }
            return View(new SearchTerm());
        }

        [HttpGet("Details")]
        public async Task<IActionResult> DetailsAsync(int id)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var log = await response.Content.ReadAsAsync<SearchTerm>();
                return View(log);
            }
            return View(new SearchTerm());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
