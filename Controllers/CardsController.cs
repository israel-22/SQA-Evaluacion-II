using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOhCards.Models;
using YuGiOhCards.Services;

namespace YuGiOhCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly YuGiOhService _yuGiOhService;

        public CardsController(YuGiOhService yuGiOhService)
        {
            _yuGiOhService = yuGiOhService;
        }

        public async Task<IActionResult> Index()
        {
            List<YuGiOhCard> cards = await _yuGiOhService.GetCardsAsync();
            return View("Home/Index", cards); // Cambiado para apuntar a Home/Index
        }

        public async Task<IActionResult> Details(int id)
        {
            var cards = await _yuGiOhService.GetCardsAsync();
            var card = cards.Find(c => c.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return View("Home/Details", card); // Cambiado para apuntar a Home/Details
        }
    }
}
