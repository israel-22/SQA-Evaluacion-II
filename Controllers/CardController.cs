namespace YuGiOhCards.Controllers


using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YuGiOhCards.Models;

public class CardController : Controller
{
    private readonly HttpClient _httpClient;

    public CardController()
    {
        _httpClient = new HttpClient();
    }

    public async Task<IActionResult> Index(int page = 1, int pageSize = 10)
    {
        string apiUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes";
        var response = await _httpClient.GetStringAsync(apiUrl);
        var data = JsonConvert.DeserializeObject<ApiResponse>(response);

        if (data == null || data.Data == null)
            return View(new List<Card>());

        // Paginación
        var paginatedCards = data.Data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling((double)data.Data.Count / pageSize);

        return View(paginatedCards);
    }

    public async Task<IActionResult> Details(int id)
    {
        string apiUrl = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?id={id}";
        var response = await _httpClient.GetStringAsync(apiUrl);
        var data = JsonConvert.DeserializeObject<ApiResponse>(response);

        if (data == null || data.Data == null || data.Data.Count == 0)
            return NotFound();

        return View(data.Data[0]);
    }
}

public class ApiResponse
{
    [JsonProperty("data")]
    public List<Card> Data { get; set; }
}
