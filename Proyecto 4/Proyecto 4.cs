using System;
using System.Collections.Generic;
using System.Linq;

class Grafo
{
    private Dictionary<string, List<string>> adyacencias;

    public Grafo()
    {
        adyacencias = new Dictionary<string, List<string>>();
    }

    // Agrega un nodo si no existe en el grafo
    public void AgregarNodo(string nodo)
    {
        if (!adyacencias.ContainsKey(nodo))
            adyacencias[nodo] = new List<string>();
    }

    // Agrega una conexión (arista) entre dos nodos (bidireccional)
    public void AgregarArista(string nodo1, string nodo2)
    {
        AgregarNodo(nodo1);
        AgregarNodo(nodo2);
        adyacencias[nodo1].Add(nodo2);
        adyacencias[nodo2].Add(nodo1); // Grafo no dirigido
    }

    // Muestra los nodos y sus conexiones
    public void MostrarGrafo()
    {
        Console.WriteLine("Representación del grafo:");
        foreach (var nodo in adyacencias)
        {
            Console.Write($"{nodo.Key}: ");
            foreach (var vecino in nodo.Value)
                Console.Write($"{vecino} ");
            Console.WriteLine();
        }
    }

    // Calcula y muestra la centralidad de grado (cuántos están conectados directamente)
    public void CalcularCentralidadDeGrado()
    {
        Console.WriteLine("\nCentralidad de Grado:");
        foreach (var nodo in adyacencias)
        {
            Console.WriteLine($"{nodo.Key}: {nodo.Value.Count}");
        }
    }

    // Calcula y muestra la centralidad de cercanía (qué tan cerca está un nodo de los demás)
    public void CalcularCentralidadDeCercania()
    {
        Console.WriteLine("\nCentralidad de Cercanía:");
        foreach (var nodo in adyacencias.Keys)
        {
            int sumaDistancias = 0;
            foreach (var otro in adyacencias.Keys)
            {
                if (nodo != otro)
                    sumaDistancias += CalcularDistancia(nodo, otro);
            }

            double cercania = sumaDistancias > 0 ? 1.0 / sumaDistancias : 0;
            Console.WriteLine($"{nodo}: {cercania:F4}");
        }
    }

    // Algoritmo BFS para calcular la distancia más corta entre dos nodos
    private int CalcularDistancia(string inicio, string destino)
    {
        Queue<string> cola = new Queue<string>();
        Dictionary<string, int> distancia = new Dictionary<string, int>();
        cola.Enqueue(inicio);
        distancia[inicio] = 0;

        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            foreach (var vecino in adyacencias[actual])
            {
                if (!distancia.ContainsKey(vecino))
                {
                    distancia[vecino] = distancia[actual] + 1;
                    cola.Enqueue(vecino);
                }
            }
        }

        return distancia.ContainsKey(destino) ? distancia[destino] : int.MaxValue;
    }
}

class Programa
{
    static void Main()
    {
        Grafo grafo = new Grafo();

        // Se crea el grafo con los siguientes nombres:
        // Luna, Jorge, Felipe, Mercedes, Lorenzo

        // Relaciones de amistad o conexiones:
        grafo.AgregarArista("Luna", "Jorge");
        grafo.AgregarArista("Luna", "Felipe");
        grafo.AgregarArista("Jorge", "Mercedes");
        grafo.AgregarArista("Felipe", "Mercedes");
        grafo.AgregarArista("Felipe", "Lorenzo");
        grafo.AgregarArista("Lorenzo", "Mercedes");

        // Mostrar estructura del grafo
        grafo.MostrarGrafo();

        // Calcular centralidad de grado (número de conexiones directas)
        grafo.CalcularCentralidadDeGrado();

        // Calcular centralidad de cercanía (qué tan cerca está de todos los demás)
        grafo.CalcularCentralidadDeCercania();

        Console.ReadLine();
    }
}
