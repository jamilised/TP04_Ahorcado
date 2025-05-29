using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04_Ahorcado.Models;
using Newtonsoft.Json;


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
        Ahorcado juego = new Ahorcado();
        juego.Inicializar();

        HttpContext.Session.SetString("Ahorcado", Objeto.ObjetoToString(juego));

        return View();
    }

    public IActionResult IniciarJuego()
    {
        Ahorcado ahor = Objeto.StringToObject<Ahorcado>(HttpContext.Session.GetString("Ahorcado"));
        
        ViewBag.Intentos = ahor.Intentos;
        ViewBag.letrasUsadasBien = ahor.letrasUsadasBien;
        ViewBag.letrasUsadasMal = ahor.letrasUsadasMal;
        ViewBag.guiones = ahor.ObtenerPalabraParcial();
        return View("Juego");
    }
    [HttpPost]
    public IActionResult ProcesarLetra(string letra)
    {
        Ahorcado ahor = Objeto.StringToObject<Ahorcado>(HttpContext.Session.GetString("Ahorcado"));

        if (ahor.ProcesarLetra(letra))
        {
            ViewBag.PalabraOculta = ahor.PalabraOculta;
            ViewBag.Intentos = ahor.Intentos;
            ViewBag.LetrasUsadasBien = ahor.letrasUsadasBien;
            ViewBag.LetrasUsadasMal = ahor.letrasUsadasMal;
            ViewBag.guiones = ahor.ObtenerPalabraParcial();
            ViewBag.ResultadoJuego = true;

            
            return View("Final");
        }
        else
        {
            ViewBag.Intentos = ahor.Intentos;
            ViewBag.LetrasUsadasBien = ahor.letrasUsadasBien;
            ViewBag.LetrasUsadasMal = ahor.letrasUsadasMal;
            ViewBag.guiones = ahor.ObtenerPalabraParcial();
            //Tiene que actualizar SOLO los intentos y letras, ahora está actualizando TODO el objeto cada ver que ingresamos una letra
            
            HttpContext.Session.SetString("Ahorcado", Objeto.ObjetoToString(ahor));
            return View("Juego");
        }
    }
    [HttpPost]
    public IActionResult ProcesarPalabra(string palabra)
    {
        Ahorcado ahor = Objeto.StringToObject<Ahorcado>(HttpContext.Session.GetString("Ahorcado"));
        ViewBag.LetrasUsadasBien = ahor.letrasUsadasBien;
        ViewBag.LetrasUsadasMal = ahor.letrasUsadasMal;
        ViewBag.Intentos = ahor.Intentos;
        ViewBag.ResultadoJuego = ahor.ProcesarPalabra(palabra);
        ViewBag.PalabraOculta = ahor.PalabraOculta;
        return View("Final");
    }



}
