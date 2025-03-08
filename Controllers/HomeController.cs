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


        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 8; // Número de cartas por página (puedes ajustarlo)
            var allCards = await _cardService.GetCardsAsync();
            int totalCards = allCards.Count;

            // Obtener las cartas para la página actual
            var cards = allCards.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPages = (int)Math.Ceiling(totalCards / (double)pageSize);

            var viewModel = new PaginatedCardsViewModel
            {
                Cards = cards,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(viewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

       
        public async Task<IActionResult> Cards()
        {
            var cards = await _cardService.GetCardsAsync();
            return View(cards);
            
        }

        
        public async Task<IActionResult> Details(int id)
        {
            var card = await _cardService.GetCardAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
            
        }

        
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
