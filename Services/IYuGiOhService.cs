using YuGiOhCards.Models;

public interface IYuGiOhService
{
    Task<List<YuGiOhCard>> GetCardsAsync(string archetype);
    Task<YuGiOhCard> GetCardByIdAsync(int id);  // Nueva función
}
