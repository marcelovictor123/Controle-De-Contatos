using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ContatoController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
