
using System.Text.Json;
using Microsoft.Extensions.Options;

public class YgoService : ICardsProvider
{
    public HttpClient Client;
    public YgoSettings Settings;

    public YgoService(IHttpClientFactory clientFactory, IOptions<YgoSettings> settings)
    {
        Client = clientFactory.CreateClient();
        Settings = settings.Value;
    }

    public async Task<Card> GetCardAsync(int cardId)
    {
        string url = $"{Settings.BaseUrl}id={cardId}";
        
        try
        {
            var request = await Client.GetAsync(url);
            if (request.IsSuccessStatusCode) 
            {
                string content = await request.Content.ReadAsStringAsync(); // JSON
                Root? model = JsonSerializer.Deserialize<Root>(content, new JsonSerializerOptions());

                Card? card = model.Data.FirstOrDefault();
                return card;
            } 
            else 
            {
                return null;
            }
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }

    public async Task<ICollection<Card>> GetCardsAsync(string search)
    {
        string url = $"{Settings.BaseUrl}fname={search}";

        try
        {
            var request = await Client.GetAsync(url);
            if (request.IsSuccessStatusCode) 
            {
                var content = await request.Content.ReadAsStringAsync();
                var model = JsonSerializer.Deserialize<Root>(content, new JsonSerializerOptions());
                return model.Data;
            }
            else {
                return null;
            }
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}