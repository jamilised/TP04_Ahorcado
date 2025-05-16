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
        return View();
    }

    public IActionResult ProcesarLetra(string letra)
    {
        if (Ahorcado.ProcesarLetra(letra))
        {
            return View("Final");
        }
        else
        {
            return View("Juego");
        }
    }
    public IActionResult ProcesarPalabra(string palabra)
    {
        if (Ahorcado.ProcesarPalabra(palabra))
        {
            ViewBag.ResultadoFinal = "true";
        }
        else
        {
            ViewBag.ResultadoFinal = "false";
        }
        return View("Final", "ViewBag.ResultadoFinal");
    }



}
