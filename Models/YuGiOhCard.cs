using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YuGiOhCards.Models
{
    public class YuGiOhCard
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("card_images")]
        public List<CardImage> CardImages { get; set; }

        [JsonPropertyName("card_prices")]
        public List<CardPrice> CardPrices { get; set; }
    }

    public class CardImage
    {
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
    }

    public class CardPrice
    {
        [JsonPropertyName("cardmarket_price")]
        public string CardMarketPrice { get; set; }
    }

    public class YuGiOhApiResponse
    {
        [JsonPropertyName("data")]
        public List<YuGiOhCard> Data { get; set; }
    }
}
