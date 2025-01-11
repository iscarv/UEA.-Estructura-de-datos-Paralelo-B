// Ejercicio3. Escribir un programa que almacene en una lista los números del 1 al 10 
//y los muestre por pantalla en orden inverso separados por comas.
using System;
using System.Collections.Generic;

namespace NumerosInversos
{
    // Clase que representa una colección de números
    public class Numeros
    {
        // Lista privada que almacena los números
        private List<int> ListaNumeros { get; set; }

        // Constructor que inicializa la lista y agrega los números del 1 al 10
        public Numeros()
        {
            // Inicializa la lista de números
            ListaNumeros = new List<int>();

            // Agrega los números del 1 al 10 a la lista
            for (int i = 1; i <= 10; i++)
            {
                ListaNumeros.Add(i);  // Agrega el número i a la lista
            }
        }

        // Método para mostrar los números en orden inverso, separados por comas
        public void MostrarNumerosInversos()
        {
            // Recorre la lista en orden inverso utilizando un bucle for
            for (int i = ListaNumeros.Count - 1; i >= 0; i--)
            {
                // Imprime el número, seguido de una coma, excepto para el último número
                if (i > 0)
                {
                    Console.Write(ListaNumeros[i] + ", ");  // Imprime el número con coma
                }
                else
                {
                    Console.Write(ListaNumeros[i]);  // Imprime el último número sin coma
                }
            }
            // Salto de línea después de imprimir todos los números
            Console.WriteLine();
        }
    }

    // Clase que contiene el punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crea una nueva instancia de la clase Numeros
            Numeros numeros = new Numeros();

            // Muestra los números en orden inverso separados por comas
            numeros.MostrarNumerosInversos();

            // Pausa la ejecución para que el usuario pueda ver el resultado
            Console.ReadLine();
        }
    }
}