
using System.Text.Json.Serialization;

public class Root
{
    [JsonPropertyName("data")]
    public List<Card> Data { get; set; }
}
