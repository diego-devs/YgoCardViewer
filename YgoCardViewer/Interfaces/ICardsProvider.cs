public interface ICardsProvider {
    public Task<Card> GetCardAsync(int cardId);
    public Task<ICollection<Card>> GetCardsAsync(string search);
}