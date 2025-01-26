using System;

class Nodo
{
    public int Valor;        // Valor del nodo
    public Nodo Siguiente;   // Referencia al siguiente nodo

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaCircular
{
    private Nodo cabeza; // Nodo inicial de la lista
    private Nodo cola;   // Nodo final de la lista

    // Método para agregar un nodo a la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);

        if (cabeza == null) // Si la lista está vacía
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
            cola.Siguiente = cabeza; // Hacer que apunte a la cabeza
        }
        else
        {
            cola.Siguiente = nuevoNodo; // Enlazar al nuevo nodo
            cola = nuevoNodo;           // Actualizar la cola
            cola.Siguiente = cabeza;    // Cerrar el círculo
        }
    }

    // Método para mostrar los elementos de la lista
    public void Mostrar()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza;
        Console.WriteLine("Elementos en la lista circular:");

        do
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        } while (actual != cabeza); // Termina cuando vuelve a la cabeza
    }
}

class Program
{
    static void Main()
    {
        ListaCircular lista = new ListaCircular();

        // Agregar elementos a la lista
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);

        // Mostrar los elementos de la lista
        lista.Mostrar();
    }
}