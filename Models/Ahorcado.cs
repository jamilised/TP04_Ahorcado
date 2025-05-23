namespace TP04_Ahorcado.Models;

public static class Ahorcado
{
    public static string PalabraOculta { get; private set; }
    public static int Intentos { get; private set; }
    public static List<char> letrasUsadasBien { get; set; } = new List<char>();
    public static List<char> letrasUsadasMal { get; set; } = new List<char>();

    public static void Inicializar()
    {
        PalabraOculta = DefinirPalabra();
        Intentos = 0;

    }
    public static string ObtenerPalabraParcial()
    {
        string resultado = "";
        foreach (char letra in PalabraOculta)
        {
            bool encontrada = false;
            foreach (char i in letrasUsadasBien)
            {
                if (letra == i)
                {
                    resultado += " " + letra + " ";
                    encontrada = true;
                }
            }
            if (!encontrada)
            {
                resultado += " _ ";
            }
        }
        return resultado;
    }

    public static bool ProcesarPalabra(string palabra)
    {
        palabra = palabra.ToLower();
        bool gano = false;

        if (palabra == PalabraOculta)
        {
            gano = true;
        }
        Intentos++;
        return gano;
    }
    public static bool ProcesarLetra(string letraEnString)
    {
        bool gano = false;
        letraEnString = letraEnString.ToLower();
        char letra;
        if (letraEnString.Length != 1)
        {
            letra = char.Parse(letraEnString);
        }
        else
        {
            letra = letraEnString[0];
        }
        {
            bool letraRepetida = false;

            List<int> Posiciones = new List<int>();

            bool seEncontroLaLetraAunqueSeaEnUnaPosicion = false;
            foreach (char l in letrasUsadasBien)
            {
                if (letra == l)
                {
                    letraRepetida = true;
                }
            }
            foreach (char l in letrasUsadasMal)
            {
                if (letra == l)
                {
                    letraRepetida = true;
                }
            }

            if (!letraRepetida)
            {
                for (int i = 0; i < PalabraOculta.Length; i++)
                {
                    if (letra == PalabraOculta[i])
                    {
                        Posiciones.Add(i);
                        seEncontroLaLetraAunqueSeaEnUnaPosicion = true;
                    }
                }
                if (seEncontroLaLetraAunqueSeaEnUnaPosicion)
                {
                    letrasUsadasBien.Add(letra);
                }
                else
                {
                    letrasUsadasMal.Add(letra);
                }
                Intentos++;

                bool todasEncontradas = true;

                for (int i = 0; i < PalabraOculta.Length; i++)
                {
                    char letraDeLaPalabra = PalabraOculta[i];
                    bool letraFueAdivinada = false;

                    foreach (char letraBuena in letrasUsadasBien)
                    {
                        if (letraDeLaPalabra == letraBuena)
                        {
                            letraFueAdivinada = true;
                        }
                    }
                    if (!letraFueAdivinada)
                    {
                        todasEncontradas = false;
                    }
                }
                if (todasEncontradas)
                {
                    gano = true;
                }
            }
            return gano;
        }


        private static string DefinirPalabra()
        {
            List<string> listaPalabrasPosibles = new List<string>();
            listaPalabrasPosibles.Add("ajedrez");
            listaPalabrasPosibles.Add("brujeria");
            listaPalabrasPosibles.Add("camaleon");
            listaPalabrasPosibles.Add("delfin");
            listaPalabrasPosibles.Add("escalera");
            listaPalabrasPosibles.Add("fantasma");
            listaPalabrasPosibles.Add("guitarra");
            listaPalabrasPosibles.Add("helicoptero");
            listaPalabrasPosibles.Add("igualmente");
            listaPalabrasPosibles.Add("jazmin");
            listaPalabrasPosibles.Add("koala");
            listaPalabrasPosibles.Add("laberinto");
            listaPalabrasPosibles.Add("murcielago");
            listaPalabrasPosibles.Add("nube");
            listaPalabrasPosibles.Add("orquidea");
            listaPalabrasPosibles.Add("pinguino");
            listaPalabrasPosibles.Add("relojero");
            listaPalabrasPosibles.Add("sandwich");
            listaPalabrasPosibles.Add("tarantula");
            listaPalabrasPosibles.Add("unicornio");
            listaPalabrasPosibles.Add("viajero");
            listaPalabrasPosibles.Add("yacimiento");
            listaPalabrasPosibles.Add("hamster");
            listaPalabrasPosibles.Add("abedul");
            listaPalabrasPosibles.Add("biblioteca");
            listaPalabrasPosibles.Add("caracol");
            listaPalabrasPosibles.Add("deporte");
            listaPalabrasPosibles.Add("elefante");
            listaPalabrasPosibles.Add("frontera");
            listaPalabrasPosibles.Add("globo");
            listaPalabrasPosibles.Add("hielo");
            listaPalabrasPosibles.Add("jungla");
            listaPalabrasPosibles.Add("leon");

            Random rd = new Random();
            int rand_num = rd.Next(0, 32);
            return listaPalabrasPosibles[rand_num];
        }

    }
}