using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Card
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("frameType")]
    public string FrameType { get; set; }

    [JsonPropertyName("desc")]
    public string Description { get; set; }

    [JsonPropertyName("atk")]
    public int Attack { get; set; }

    [JsonPropertyName("def")]
    public int Defense { get; set; }

    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("race")]
    public string Race { get; set; }

    [JsonPropertyName("attribute")]
    public string Attribute { get; set; }

    [JsonPropertyName("ygoprodeck_url")]
    public string YgoProDeckUrl { get; set; }

    [JsonPropertyName("card_sets")]
    public List<CardSet> CardSets { get; set; }

    [JsonPropertyName("card_images")]
    public List<CardImage> CardImages { get; set; }

    [JsonPropertyName("card_prices")]
    public List<CardPrice> CardPrices { get; set; }
}




