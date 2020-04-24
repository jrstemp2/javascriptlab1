using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoTAPI.Models;
using System.Net.Http;

namespace GoTAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCharacterInfo(string name)
        {
            int id;
            
            if(name == "Jon Snow")
            {
                id = 583; 
            }
            else if (name == "Asha Greyjoy")
            {
                id = 150;
            }
            else if (name == "Denys Mallister")
            {
                id = 303;
            }
            else if(name == "Dennis Plumm")
            {
                id = 299;
            }
            else
            {
                id = 700;
            }
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://anapioficeandfire.com/");
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; GrandCircus/1.0)");

            var response = await client.GetAsync($"api/characters/{id}");
            var character = await response.Content.ReadAsAsync<Character>();

            return View(character);
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
