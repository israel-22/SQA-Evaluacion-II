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

        // Modificamos para que `archetype` sea un parámetro
        public async Task<IActionResult> Index(string archetype = "Blue-Eyes")  // valor predeterminado si no se pasa `archetype`
        {
            // Pasamos correctamente el `archetype` al servicio
            List<YuGiOhCard> cards = await _yuGiOhService.GetCardsAsync(archetype);
            return View("Home/Index", cards);  // Cambiado para apuntar a Home/Index
        }

        public async Task<IActionResult> Details(int id, string archetype = "Blue-Eyes")
        {
            // Pasamos el `archetype` al servicio
            List<YuGiOhCard> cards = await _yuGiOhService.GetCardsAsync(archetype);

            // Buscamos la carta con el `id` dado
            var card = cards.Find(c => c.Id == id);

            // Si no se encuentra la carta, devolvemos un error 404
            if (card == null)
            {
                return NotFound();
            }

            return View("Home/Details", card);  // Cambiado para apuntar a Home/Details
        }
    }
}
