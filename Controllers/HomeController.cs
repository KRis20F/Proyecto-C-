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
        string url = "https://ch.tetr.io/api/general/stats";

        HttpClient client = new HttpClient();

        HttpResponseMessage response = client.GetAsync(url).Result;
        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        var ObjectGlobal = JsonConvert.DeserializeObject<InfoGlobal.Root>(jsonResponse);

        // Crear una lista con un solo elemento
        var modelList = new List<InfoGlobal.Root>() { ObjectGlobal };

        return View(modelList);
    }

    public async Task<IActionResult> Search(string username) 
    {
        string url = $"https://ch.tetr.io/api/users/{username}";

        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            ViewBag.ErrorMessage = "Usuario no encontrado";
            return View("SearchResults"); // Vuelve a la vista principal si hay un error
        }


        string jsonResponse = response.Content.ReadAsStringAsync().Result;

        var jsonObjectsSearch = JsonConvert.DeserializeObject<SearchUser.Root>(jsonResponse);

        if (!jsonObjectsSearch.success)
        {
            ViewBag.ErrorMessage = "Usuario no encontrado";
            return View("SearchResults"); 
        }

        return View("SearchResults", jsonObjectsSearch);
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
