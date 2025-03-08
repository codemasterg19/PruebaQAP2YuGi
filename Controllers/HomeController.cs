using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PruebaQAP2.Models;
using PruebaQAP2.Services;

namespace PruebaQAP2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CardService _cardService;

        // Constructor que inyecta tanto ILogger como CardService
        public HomeController(ILogger<HomeController> logger, CardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
        }

        // Acción que retorna la lista de cartas a la vista Index
        public async Task<IActionResult> Index()
        {
            var cards = await _cardService.GetCardsAsync();
            return View(cards);  // Se pasa la lista de cartas a la vista
        }

        // Acción para la vista Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Acción adicional para mostrar las cartas (si deseas tener una acción separada)
        public async Task<IActionResult> Cards()
        {
            var cards = await _cardService.GetCardsAsync();
            return View(cards);
            // Buscará la vista en Views/Home/Cards.cshtml
        }

        // Acción para mostrar el detalle de una carta específica
        public async Task<IActionResult> Details(int id)
        {
            var card = await _cardService.GetCardAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
            // Buscará la vista en Views/Home/Details.cshtml
        }

        // Acción de error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
