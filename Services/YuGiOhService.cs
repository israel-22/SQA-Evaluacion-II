
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using YuGiOhCards.Models;

namespace YuGiOhCards.Services
{
    public class YuGiOhService : IYuGiOhService
    {
        private readonly HttpClient _httpClient;
        private const string apiUrl = "https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes";

        public YuGiOhService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<YuGiOhCard>> GetCards()
        {
            var response = await _httpClient.GetStringAsync(apiUrl);
            var result = JsonSerializer.Deserialize<YuGiOhApiResponse>(response);
            return result?.Data ?? new List<YuGiOhCard>();
        }

        public async Task<YuGiOhCard> GetCardById(int id)
        {
            var cards = await GetCards();
            return cards.Find(c => c.Id == id);
        }
    }
}
