using PruebaQAP2.Models;
using Newtonsoft.Json;


namespace PruebaQAP2.Services
{
    public class CardService
    {
        private readonly HttpClient _httpClient;

        public CardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Card>> GetCardsAsync()
        {
            var response = await _httpClient.GetStringAsync("https://db.ygoprodeck.com/api/v7/cardinfo.php?archetype=Blue-Eyes");
            var cardResponse = JsonConvert.DeserializeObject<CardResponse>(response);
            return cardResponse?.data ?? new List<Card>();
        }

        public async Task<Card> GetCardAsync(int id)
        {
            var cards = await GetCardsAsync();
            return cards.FirstOrDefault(card => card.id == id);
        }
    }
}