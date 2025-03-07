
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOhCards.Models;

namespace YuGiOhCards.Services
{
    public interface IYuGiOhService
    {
        Task<List<YuGiOhCard>> GetCards();
        Task<YuGiOhCard> GetCardById(int id);
    }
}
