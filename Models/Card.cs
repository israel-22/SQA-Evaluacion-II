namespace YuGiOhCards.Models
using System.Collections.Generic;
using Newtonsoft.Json;

public class Card
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("card_images")]
    public List<CardImage> CardImages { get; set; }

    [JsonProperty("card_prices")]
    public List<CardPrice> CardPrices { get; set; }
}

public class CardImage
{
    [JsonProperty("image_url")]
    public string ImageUrl { get; set; }
}

public class CardPrice
{
    [JsonProperty("amazon_price")]
    public string AmazonPrice { get; set; }
}
