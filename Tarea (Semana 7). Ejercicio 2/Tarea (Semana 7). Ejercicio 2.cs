//2.	Realice un algoritmo en C# y el uso de pilas para resolver el problema de las torres de Hanoi.
using System;
using System.Collections.Generic;

class TorresDeHanoi
{
    public static void ResolverHanoi(int discos, string origen, string auxiliar, string destino)
    {
        // Crear las pilas para las torres
        Stack<int> torreOrigen = new Stack<int>();
        Stack<int> torreAuxiliar = new Stack<int>();
        Stack<int> torreDestino = new Stack<int>();

        // Llenar la torre de origen con discos
        for (int i = discos; i >= 1; i--)
        {
            torreOrigen.Push(i);
        }

        // Mostrar el estado inicial de las torres
        MostrarEstado(torreOrigen, torreAuxiliar, torreDestino);

        // Usar un ciclo iterativo para mover los discos
        int totalMovimientos = (int)Math.Pow(2, discos) - 1;
        for (int i = 1; i <= totalMovimientos; i++)
        {
            // Si el movimiento es impar, mover de la torre de origen a la torre de destino
            if (i % 3 == 1)
            {
                MoverDisco(torreOrigen, torreDestino);
            }
            // Si el movimiento es par, mover de la torre de origen a la torre auxiliar
            else if (i % 3 == 2)
            {
                MoverDisco(torreOrigen, torreAuxiliar);
            }
            // Si el movimiento es múltiplo de 3, mover de la torre auxiliar a la torre de destino
            else
            {
                MoverDisco(torreAuxiliar, torreDestino);
            }

            // Mostrar el estado actual de las torres
            MostrarEstado(torreOrigen, torreAuxiliar, torreDestino);
        }
    }

    public static void MoverDisco(Stack<int> origen, Stack<int> destino)
    {
        // Mover el disco superior de la pila origen a la pila destino
        if (origen.Count > 0)
        {
            int disco = origen.Pop();
            destino.Push(disco);
        }
    }

    public static void MostrarEstado(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
    {
        // Mostrar el estado de las tres torres
        Console.WriteLine("Torre de origen: " + string.Join(", ", origen));
        Console.WriteLine("Torre auxiliar: " + string.Join(", ", auxiliar));
        Console.WriteLine("Torre de destino: " + string.Join(", ", destino));
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int discos = 3; // Cambia este valor para probar con más discos
        ResolverHanoi(discos, "Origen", "Auxiliar", "Destino");
    }
}