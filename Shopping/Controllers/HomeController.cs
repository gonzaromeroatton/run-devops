using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("products");
            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonSerializer.Deserialize<List<Product>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
