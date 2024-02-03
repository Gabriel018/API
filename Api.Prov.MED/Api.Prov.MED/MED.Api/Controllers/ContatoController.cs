using Microsoft.AspNetCore.Mvc;

namespace MED.Api.Controllers
{
    [ApiController]
    [Route("{controllert}")]
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
