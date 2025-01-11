using System;
using System.Collections.Generic;
using System.Linq;  // Añadir esta línea para usar LINQ

namespace Precios
{
    // Clase que representa una colección de precios
    public class Precios
    {
        // Lista privada que almacena los precios
        private List<int> ListaPrecios { get; set; }

        // Constructor que inicializa la lista de precios
        public Precios()
        {
            // Inicializa la lista de precios con los valores dados
            ListaPrecios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        }

        // Método que obtiene el precio menor de la lista
        public int ObtenerPrecioMenor()
        {
            // Usa el método Min de LINQ para obtener el precio más bajo
            return ListaPrecios.Min();
        }

        // Método que obtiene el precio mayor de la lista
        public int ObtenerPrecioMayor()
        {
            // Usa el método Max de LINQ para obtener el precio más alto
            return ListaPrecios.Max();
        }
    }

    // Clase que contiene el punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crea una nueva instancia de la clase Precios
            Precios precios = new Precios();

            // Obtiene el precio menor de la lista
            int precioMenor = precios.ObtenerPrecioMenor();
            // Obtiene el precio mayor de la lista
            int precioMayor = precios.ObtenerPrecioMayor();

            // Muestra el precio menor y el mayor
            Console.WriteLine($"El precio menor es: {precioMenor}");
            Console.WriteLine($"El precio mayor es: {precioMayor}");

            // Pausa la ejecución para que el usuario pueda ver el resultado
            Console.ReadLine();
        }
    }
}