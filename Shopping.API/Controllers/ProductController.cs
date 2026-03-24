using Microsoft.AspNetCore.Mvc;

namespace Shoping.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return View();
    }
}
