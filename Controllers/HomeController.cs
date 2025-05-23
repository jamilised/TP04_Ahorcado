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
        Ahorcado.Inicializar();
        return View();
    }

    public IActionResult IniciarJuego()
    {
        ViewBag.Intentos = Ahorcado.Intentos;
        ViewBag.letrasUsadasBien = Ahorcado.letrasUsadasBien;
        ViewBag.letrasUsadasMal = Ahorcado.letrasUsadasMal;
        ViewBag.guiones = Ahorcado.ObtenerPalabraParcial();
        return View("Juego");
    }
    [HttpPost]
    public IActionResult ProcesarLetra(string letra)
    {
        if (Ahorcado.ProcesarLetra(letra))
        {
            ViewBag.PalabraOculta = Ahorcado.PalabraOculta;
            ViewBag.Intentos = Ahorcado.Intentos;
            ViewBag.LetrasUsadasBien = Ahorcado.letrasUsadasBien;
            ViewBag.LetrasUsadasMal = Ahorcado.letrasUsadasMal;
            ViewBag.guiones = Ahorcado.ObtenerPalabraParcial();
            ViewBag.ResultadoJuego = true;
            return View("Final");
        }
        else
        {
            ViewBag.Intentos = Ahorcado.Intentos;
            ViewBag.LetrasUsadasBien = Ahorcado.letrasUsadasBien;
            ViewBag.LetrasUsadasMal = Ahorcado.letrasUsadasMal;
            ViewBag.guiones = Ahorcado.ObtenerPalabraParcial();
            return View("Juego");
        }
    }
    [HttpPost]
    public IActionResult ProcesarPalabra(string palabra)
    {
        ViewBag.LetrasUsadasBien = Ahorcado.letrasUsadasBien;
        ViewBag.LetrasUsadasMal = Ahorcado.letrasUsadasMal;
        ViewBag.Intentos = Ahorcado.Intentos;
        ViewBag.ResultadoJuego = Ahorcado.ProcesarPalabra(palabra);
        ViewBag.PalabraOculta = Ahorcado.PalabraOculta;
        return View("Final");
    }



}
