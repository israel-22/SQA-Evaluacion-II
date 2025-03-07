using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using YuGiOhCards.Models;  // Asegúrate de que el espacio de nombres del modelo es correcto
using YuGiOhCards.Services;

namespace YuGiOhCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYuGiOhService _yuGiOhService;

        public HomeController(IYuGiOhService yuGiOhService)
        {
            _yuGiOhService = yuGiOhService;
        }

        // Acción Index para mostrar las cartas
        public async Task<IActionResult> Index(string archetype = "Blue-Eyes")
        {
            // Llamada al servicio para obtener las cartas según el archetype
            var cards = await _yuGiOhService.GetCardsAsync(archetype);
            return View(cards);  // Pasa las cartas a la vista Index
        }

        // Acción Details para mostrar los detalles de una carta
        public async Task<IActionResult> Details(int id)
        {
            // Llamada al servicio para obtener la carta por ID (mejor que obtener todas las cartas)
            var card = await _yuGiOhService.GetCardByIdAsync(id);  // Asumiendo que tienes esta función en el servicio
            if (card == null)
            {
                return NotFound();  // Si no se encuentra la carta, devuelve NotFound
            }
            return View(card);  // Pasa los detalles de la carta a la vista Details
        }
    }
}
