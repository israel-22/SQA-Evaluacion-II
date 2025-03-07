using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOhCards.Models;
using YuGiOhCards.Services;

namespace YuGiOhCards.Controllers
{
    public class YuGiOhController : Controller
    {
        private readonly IYuGiOhService _yuGiOhService;

        public YuGiOhController(IYuGiOhService yuGiOhService)
        {
            _yuGiOhService = yuGiOhService;
        }

        public async Task<IActionResult> Index()
        {
            List<YuGiOhCard> cards = await _yuGiOhService.GetCards();
            return View(cards);
        }

        public async Task<IActionResult> Details(int id)
        {
            YuGiOhCard card = await _yuGiOhService.GetCardById(id);
            if (card == null) return NotFound();
            return View(card);
        }
    }
}
