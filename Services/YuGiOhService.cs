using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YuGiOhCards.Models;

namespace YuGiOhCards.Services
{
    public class YuGiOhService : IYuGiOhService
    {
        private readonly HttpClient _httpClient;

        public YuGiOhService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<YuGiOhCard>> GetCardsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes");
            var cards = JsonConvert.DeserializeObject<List<YuGiOhCard>>(response);
            return cards;
        }
    }
}
