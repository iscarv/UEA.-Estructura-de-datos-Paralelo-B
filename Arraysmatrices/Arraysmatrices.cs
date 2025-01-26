using System;

class Program
{
    static void Main(string[] args)
    {
        // Ejemplo de Array Unidimensional
        Console.WriteLine("Array Unidimensional:");
        int[] numeros = { 10, 20, 30 };

        // Mostrar los elementos del array
        Console.WriteLine($"Primer elemento: {numeros[0]}"); // 10
        Console.WriteLine($"Segundo elemento: {numeros[1]}"); // 20
        Console.WriteLine($"Tercer elemento: {numeros[2]}"); // 30

        // Ejemplo de Matriz Bidimensional
        Console.WriteLine("\nMatriz Bidimensional:");
        int[,] matriz = {
            { 1, 2 },
            { 3, 4 }
        };

        // Mostrar los elementos de la matriz
        Console.WriteLine($"Elemento en [0, 0]: {matriz[0, 0]}"); // 1
        Console.WriteLine($"Elemento en [0, 1]: {matriz[0, 1]}"); // 2
        Console.WriteLine($"Elemento en [1, 0]: {matriz[1, 0]}"); // 3
        Console.WriteLine($"Elemento en [1, 1]: {matriz[1, 1]}"); // 4
    }
}