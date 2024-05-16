using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Proyecto.Models;

using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Proyecto.Controllers;

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

    public IActionResult TopRank()
    {
        string url = "https://ch.tetr.io/api/users/lists/league";

        HttpClient client = new HttpClient();

        HttpResponseMessage response = client.GetAsync(url).Result;
        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        var rankObject = JsonConvert.DeserializeObject<TopRank>(jsonResponse);

        return View(rankObject);
    }

    public IActionResult TopSprint()
    {
        string url = "https://jstris.jezevec10.com/api/leaderboard/1?mode=1";

        HttpClient client = new HttpClient();

        HttpResponseMessage response = client.GetAsync(url).Result;
        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        var rankObject = JsonConvert.DeserializeObject<List<TopSprint.Root>>(jsonResponse);

        var top10RankObjects = rankObject.Take(10).ToList();

        return View(top10RankObjects);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
