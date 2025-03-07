using Newtonsoft.Json;
using YuGiOhCards.Models;
using YuGiOhCards.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class YuGiOhService : IYuGiOhService
{
    private readonly HttpClient _httpClient;

    public YuGiOhService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Método para obtener las cartas de un archetype
    public async Task<List<YuGiOhCard>> GetCardsAsync(string archetype)
    {
        var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype={archetype}";
        var response = await _httpClient.GetStringAsync(url);

        // Asegurándonos de que la respuesta contiene el campo "data" que es una lista de cartas
        var apiResponse = JsonConvert.DeserializeObject<YuGiOhApiResponse>(response);
        return apiResponse?.Data ?? new List<YuGiOhCard>();  // Si no hay cartas, devuelve una lista vacía
    }

    // Método para obtener los detalles de una carta por ID
    public async Task<YuGiOhCard> GetCardDetailsAsync(string cardId)
    {
        var url = $"https://db.ygoprodeck.com/api/v7/cardinfo.php?id={cardId}";
        var response = await _httpClient.GetStringAsync(url);

        // Deserializamos la respuesta y devolvemos los detalles de la carta
        var cardDetails = JsonConvert.DeserializeObject<YuGiOhCard>(response);
        return cardDetails;
    }
}
