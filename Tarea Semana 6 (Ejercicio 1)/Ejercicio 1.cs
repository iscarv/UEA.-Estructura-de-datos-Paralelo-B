// Ejercicio1. Implementar el método de búsqueda en la clase lista, 
//el cual debe retornar el número de veces que se encuentra el dato dentro de la lista. 
//En caso de no encontrarse, el método debe mostrar un mensaje indicando que el dato no fue encontrado.
//El parámetro de entrada del método es el valor que se desea buscar. 
using System;

namespace ListasEnlazadas
{
    // Clase Nodo: Representa cada elemento de la lista enlazada
    public class Nodo
    {
        public int Dato { get; set; } // Dato almacenado en el nodo
        public Nodo? Siguiente { get; set; } // Referencia al siguiente nodo (puede ser null)

        // Constructor para inicializar un nodo con un dato
        public Nodo(int dato)
        {
            Dato = dato; // Asignar el valor al nodo
            Siguiente = null; // El siguiente nodo inicialmente es null
        }
    }

    // Clase ListaEnlazada: Gestiona la estructura de la lista enlazada
    public class ListaEnlazada
    {
        private Nodo? cabeza; // Referencia al primer nodo de la lista (puede ser null si está vacía)

        // Constructor para inicializar la lista como vacía
        public ListaEnlazada()
        {
            cabeza = null; // La lista comienza vacía
        }

        // Método para agregar un nuevo dato a la lista al final
        public void Agregar(int dato)
        {
            if (cabeza == null)
            {
                // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
                cabeza = new Nodo(dato);
            }
            else
            {
                // Recorrer la lista hasta el último nodo
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                // Agregar el nuevo nodo al final de la lista
                actual.Siguiente = new Nodo(dato);
            }
        }

        // Método para buscar un dato en la lista y contar cuántas veces aparece
        public int Buscar(int dato)
        {
            Nodo? actual = cabeza; // Iniciar desde la cabeza de la lista
            int contador = 0; // Contador para almacenar cuántas veces se encuentra el dato

            while (actual != null)
            {
                if (actual.Dato == dato) // Comparar el dato actual con el buscado
                {
                    contador++; // Incrementar el contador si hay coincidencia
                }
                actual = actual.Siguiente; // Avanzar al siguiente nodo
            }

            // Imprimir un mensaje dependiendo del resultado de la búsqueda
            if (contador == 0)
            {
                Console.WriteLine("El dato no fue encontrado en la lista.");
            }
            else
            {
                Console.WriteLine($"El dato {dato} se encontró {contador} vez/veces en la lista.");
            }

            return contador; // Retornar el número de veces que se encontró el dato
        }

        // Método para mostrar todos los elementos de la lista enlazada
        public void Mostrar()
        {
            Nodo? actual = cabeza; // Iniciar desde la cabeza de la lista
            while (actual != null)
            {
                Console.Write(actual.Dato + " -> "); // Imprimir el dato del nodo actual
                actual = actual.Siguiente; // Avanzar al siguiente nodo
            }
            Console.WriteLine("null"); // Indicar el final de la lista
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            // Agregar elementos a la lista
            lista.Agregar(7); // Agregar el número 7
            lista.Agregar(10); // Agregar el número 10
            lista.Agregar(8); // Agregar el número 8
            lista.Agregar(7); // Agregar el número 7 nuevamente

            // Mostrar los elementos de la lista
            Console.WriteLine("Elementos en la lista:");
            lista.Mostrar(); // Llama al método Mostrar para imprimir la lista

            // Buscar elementos en la lista
            lista.Buscar(7);  // Buscar el número 7, que debería aparecer 2 veces
            lista.Buscar(15); // Buscar el número 15, que no está en la lista
        }
    }
}