using YuGiOhCards.Models;

namespace YuGiOhCards.Services
{
    public interface IYuGiOhService
    {
        Task<List<YuGiOhCard>> GetCardsAsync(); // Aquí defines los métodos que necesitas, como obtener cartas.
    }
}
