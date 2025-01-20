//Ejercicio2. Crear una lista enlazada con 50 números enteros, del 1 al 999 generados aleatoriamente. 
//Una vez creada la lista, se deben eliminar los nodos que estén fuera de un rango de valores leídos desde el teclado.
using System;

namespace ListasEnlazadas1
{
    // Clase que representa un nodo en la lista enlazada
    public class Nodo
    {
        public int Dato { get; set; } // Valor almacenado en el nodo
        public Nodo? Siguiente { get; set; } // Referencia al siguiente nodo (puede ser null)

        // Constructor que inicializa el dato y deja el siguiente como null
        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }

    // Clase que gestiona la lista enlazada
    public class ListaEnlazada
    {
        private Nodo? cabeza; // Referencia al primer nodo de la lista (puede ser null si está vacía)

        // Constructor que inicializa la lista como vacía
        public ListaEnlazada()
        {
            cabeza = null;
        }

        // Método para agregar un nuevo nodo al final de la lista
        public void Agregar(int dato)
        {
            if (cabeza == null)
            {
                // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
                cabeza = new Nodo(dato);
            }
            else
            {
                // Recorrer la lista hasta encontrar el último nodo
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                // Agregar el nuevo nodo al final
                actual.Siguiente = new Nodo(dato);
            }
        }

        // Método para mostrar los elementos de la lista enlazada
        public void Mostrar()
        {
            Nodo? actual = cabeza;
            while (actual != null)
            {
                // Imprimir el dato del nodo actual y avanzar al siguiente nodo
                Console.Write(actual.Dato + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null"); // Indicar el final de la lista
        }

        // Método para eliminar los nodos cuyos valores estén fuera de un rango dado
        public void EliminarFueraDeRango(int limiteInferior, int limiteSuperior)
        {
            // Eliminar nodos desde la cabeza que estén fuera del rango
            while (cabeza != null && (cabeza.Dato < limiteInferior || cabeza.Dato > limiteSuperior))
            {
                // Mover la cabeza al siguiente nodo
                cabeza = cabeza.Siguiente;
            }

            // Revisar los nodos restantes a partir de la cabeza
            Nodo? actual = cabeza;
            while (actual != null && actual.Siguiente != null)
            {
                // Si el siguiente nodo está fuera del rango, saltarlo
                if (actual.Siguiente.Dato < limiteInferior || actual.Siguiente.Dato > limiteSuperior)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente; // Saltar el nodo
                }
                else
                {
                    // Avanzar al siguiente nodo
                    actual = actual.Siguiente;
                }
            }
        }
    }

    // Clase principal para ejecutar el programa
    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();
            Random random = new Random();

            // Generar 50 números aleatorios entre 1 y 999
            for (int i = 0; i < 50; i++)
            {
                lista.Agregar(random.Next(1, 1000)); // Agregar el número a la lista
            }

            // Mostrar la lista original
            Console.WriteLine("Lista original:");
            lista.Mostrar();

            // Solicitar al usuario los límites del rango
            Console.Write("Ingresa el límite inferior del rango: ");
            int limiteInferior = int.Parse(Console.ReadLine() ?? "0"); // Leer el límite inferior

            Console.Write("Ingresa el límite superior del rango: ");
            int limiteSuperior = int.Parse(Console.ReadLine() ?? "0"); // Leer el límite superior

            // Eliminar los nodos que estén fuera del rango especificado
            lista.EliminarFueraDeRango(limiteInferior, limiteSuperior);

            // Mostrar la lista después de eliminar nodos fuera del rango
            Console.WriteLine("\nLista después de eliminar nodos fuera del rango:");
            lista.Mostrar();
        }
    }
}