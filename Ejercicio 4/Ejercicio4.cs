// Ejercicio4. Escribir un programa que pida al usuario una palabra y muestre por pantalla si es un palíndromo.
using System;
using System.Collections.Generic;

namespace ChequearPalindromo
{
    // Clase que contiene la lógica para verificar si una palabra es un palíndromo
    public class Palindromo
    {
        // Método que recibe una palabra y verifica si es un palíndromo
        public bool EsPalindromo(string palabra)
        {
            // Convierte la palabra a minúsculas para hacer la comparación insensible a mayúsculas/minúsculas
            palabra = palabra.ToLower();

            // Crea una lista para almacenar los caracteres de la palabra
            List<char> caracteres = new List<char>();

            // Agrega cada carácter de la palabra a la lista
            foreach (char c in palabra)
            {
                caracteres.Add(c);
            }

            // Verifica si los caracteres de la lista forman un palíndromo
            int izquierda = 0;
            int derecha = caracteres.Count - 1;

            // Compara los caracteres de ambos extremos hacia el centro
            while (izquierda < derecha)
            {
                if (caracteres[izquierda] != caracteres[derecha])
                {
                    return false;  // Si los caracteres no son iguales, no es un palíndromo
                }
                izquierda++;
                derecha--;
            }

            // Si no se encontraron diferencias, la palabra es un palíndromo
            return true;
        }
    }

    // Clase que contiene el punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Pide al usuario una palabra
            Console.WriteLine("Introduce una palabra:");
            string palabra = Console.ReadLine();

            // Crea una instancia de la clase Palindromo
            Palindromo palindromo = new Palindromo();

            // Verifica si la palabra es un palíndromo
            bool esPalindromo = palindromo.EsPalindromo(palabra);

            // Muestra el resultado
            if (esPalindromo)
            {
                Console.WriteLine($"La palabra '{palabra}' es un palíndromo.");
            }
            else
            {
                Console.WriteLine($"La palabra '{palabra}' no es un palíndromo.");
            }

            // Pausa la ejecución para que el usuario pueda ver el resultado
            Console.ReadLine();
        }
    }
}
