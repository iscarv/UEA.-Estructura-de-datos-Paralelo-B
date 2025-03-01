using System;
using System.Collections.Generic;

class Traductor
{
    static void Main(string[] args)
    {
        // Diccionario inicial con traducciones inglés-español
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Time", "tiempo" },
            { "Person", "persona" },
            { "Year", "año" },
            { "Way", "camino" },
            { "Day", "día" },
            { "Thing", "cosa" },
            { "Man", "hombre" },
            { "World", "mundo" },
            { "Life", "vida" },
            { "Hand", "mano" },
            { "Part", "parte" },
            { "Child", "niño" },
            { "Eye", "ojo" },
            { "Woman", "mujer" },
            { "Place", "lugar" },
            { "Work", "trabajo" },
            { "Week", "semana" },
            { "Case", "caso" },
            { "Point", "punto" },
            { "Government", "gobierno" },
            { "Company", "empresa" }
        };

        while (true)
        {
            // Menú principal del programa
            Console.Clear();
            Console.WriteLine("MENU");
            Console.WriteLine("=======================================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Ingresar más palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                // Opción para traducir una frase ingresada por el usuario
                Console.Write("Ingrese la frase: ");
                string frase = Console.ReadLine();

                // Validar que la frase no sea nula o vacía
                if (string.IsNullOrEmpty(frase))
                {
                    Console.WriteLine("La frase no puede estar vacía.");
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                // Separar la frase en palabras
                string[] palabras = frase.Split(' ');
                List<string> fraseTraducida = new List<string>();

                foreach (string palabra in palabras)
                {
                    // Eliminar puntuaciones iniciales y finales de la palabra
                    string palabraSinPuntuacion = palabra.Trim(new char[] { ',', '.', '!', '?', ';', ':' });

                    // Si la palabra es nula o vacía después de limpiar, se deja igual
                    if (string.IsNullOrEmpty(palabraSinPuntuacion))
                    {
                        fraseTraducida.Add(palabra);
                        continue;
                    }

                    // Variables para almacenar puntuación antes y después de la palabra
                    string prefijoPuntuacion = "", sufijoPuntuacion = "";

                    // Extraer puntuación inicial
                    int i = 0;
                    while (i < palabra.Length && char.IsPunctuation(palabra[i]))
                    {
                        prefijoPuntuacion += palabra[i];
                        i++;
                    }

                    // Extraer puntuación final
                    int j = palabra.Length - 1;
                    while (j >= 0 && char.IsPunctuation(palabra[j]))
                    {
                        sufijoPuntuacion = palabra[j] + sufijoPuntuacion;
                        j--;
                    }

                    string traduccion = null;

                    // Buscar en el diccionario si la palabra está en inglés
                    if (diccionario.ContainsKey(palabraSinPuntuacion))
                    {
                        traduccion = diccionario[palabraSinPuntuacion];
                    }
                    else
                    {
                        // Buscar si la palabra está en español y obtener su traducción al inglés
                        foreach (var entrada in diccionario)
                        {
                            if (string.Equals(entrada.Value, palabraSinPuntuacion, StringComparison.OrdinalIgnoreCase))
                            {
                                traduccion = entrada.Key;
                                break;
                            }
                        }
                    }

                    // Si la palabra no está en el diccionario, se deja igual
                    string palabraTraducida = traduccion ?? palabraSinPuntuacion;

                    // Restaurar puntuación alrededor de la palabra
                    palabraTraducida = prefijoPuntuacion + palabraTraducida + sufijoPuntuacion;

                    // Agregar la palabra traducida a la lista
                    fraseTraducida.Add(palabraTraducida);
                }

                // Mostrar la frase traducida
                Console.WriteLine("\nSu frase traducida es: " + string.Join(" ", fraseTraducida));
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else if (opcion == "2")
            {
                // Opción para agregar nuevas palabras al diccionario
                Console.Write("Ingrese la palabra en inglés: ");
                string palabraIngles = Console.ReadLine()?.Trim();

                Console.Write("Ingrese la traducción al español: ");
                string traduccionEspañol = Console.ReadLine()?.Trim();

                // Validar que las palabras ingresadas no sean nulas o vacías
                if (string.IsNullOrEmpty(palabraIngles) || string.IsNullOrEmpty(traduccionEspañol))
                {
                    Console.WriteLine("No se pueden ingresar valores vacíos.");
                }
                else if (!diccionario.ContainsKey(palabraIngles))
                {
                    // Agregar nueva palabra al diccionario
                    diccionario.Add(palabraIngles, traduccionEspañol);
                    Console.WriteLine("Palabra añadida correctamente.");
                }
                else
                {
                    Console.WriteLine("La palabra ya está en el diccionario.");
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
            else if (opcion == "0")
            {
                // Opción para salir del programa
                break;
            }
            else
            {
                // Mensaje de error para opción inválida
                Console.WriteLine("Opción no válida, intente nuevamente.");
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
