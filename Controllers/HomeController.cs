using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YuGiOhCards.Services;  // Asegúrate de que el espacio de nombres del servicio sea correcto
using YuGiOhCards.Models;    // Si es necesario para las clases de modelo

namespace YuGiOhCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly IYuGiOhService _yuGiOhService;

        // Constructor con inyección de dependencias
        public HomeController(IYuGiOhService yuGiOhService)
        {
            _yuGiOhService = yuGiOhService;
        }

        // Acción para la vista principal (Index)
        public async Task<IActionResult> Index()
        {
            var cards = await _yuGiOhService.GetCardsAsync("Blue-Eyes");
            return View(cards);  // Pasa la lista de cartas a la vista
        }

        // Acción para la vista de detalles de la carta
        public async Task<IActionResult> Details(string cardId)
        {
            var cardDetails = await _yuGiOhService.GetCardDetailsAsync(cardId);
            return View(cardDetails);  // Pasa los detalles de la carta a la vista
        }

        // Acción para la vista de crear carta (opcional)
        public IActionResult Create()
        {
            return View();
        }

        // Acción POST para crear carta (opcional)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Acción para la vista de editar carta (opcional)
        public IActionResult Edit(int id)
        {
            return View();
        }

        // Acción POST para editar carta (opcional)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // Acción para eliminar carta (opcional)
        public IActionResult Delete(int id)
        {
            return View();
        }

        // Acción POST para eliminar carta (opcional)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
