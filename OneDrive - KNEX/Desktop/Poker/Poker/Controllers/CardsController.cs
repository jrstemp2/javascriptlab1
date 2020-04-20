using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Poker.Models;                                                                                                                                        

namespace Poker.Controllers
{
    public class CardsController : Controller
    {
        public async Task<IActionResult> Index() //shuffle the deck and land on index
        {
            var client = new HttpClient();
            
            client.BaseAddress = new Uri("https://deckofcardsapi.com");


            var response = await client.GetAsync("api/deck/new/shuffle/?deck_count=1");

            
            var deck = await response.Content.ReadAsAsync<Deck>();
            //var deck_id = deck.Data.Deck_Id;

            return View(deck);
        }

        public IActionResult Draw()
        {
            return View();
        }
    }
}