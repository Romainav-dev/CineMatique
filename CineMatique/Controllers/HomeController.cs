using Microsoft.AspNetCore.Mvc;

namespace CineMatique.Controllers;

public class HomeController : Controller
{
    public IActionResult Accueil()
    {
        return View();
    }
}