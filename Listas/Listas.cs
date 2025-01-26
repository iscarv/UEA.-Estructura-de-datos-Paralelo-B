using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear una lista de números
        List<int> numeros = new List<int>();

        // Agregar elementos a la lista
        numeros.Add(10);
        numeros.Add(20);
        numeros.Add(30);

        // Mostrar los elementos de la lista
        Console.WriteLine("Lista de números:");
        foreach (int numero in numeros)
        {
            Console.WriteLine(numero);
        }
    }
}