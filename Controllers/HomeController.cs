using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Ahorcado.Models;

namespace TP04_Ahorcado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.PalabraOculta = Ahorcado.PalabraElegida();
        return ("ViewBag.PalabraOculta");
    }
    public IActionResult ArriesgarLetra(String letra)
    {
        
    }


}
