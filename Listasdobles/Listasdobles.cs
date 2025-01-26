using System;

class Nodo
{
    public int Valor;         // Valor del nodo
    public Nodo Anterior;     // Referencia al nodo anterior
    public Nodo Siguiente;    // Referencia al nodo siguiente

    public Nodo(int valor)
    {
        Valor = valor;
        Anterior = null;
        Siguiente = null;
    }
}

class ListaDobleEnlazada
{
    private Nodo cabeza; // Primer nodo de la lista
    private Nodo cola;   // Último nodo de la lista

    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);

        if (cabeza == null) // Si la lista está vacía
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo; // Enlazar al final
            nuevoNodo.Anterior = cola; // Enlazar hacia atrás
            cola = nuevoNodo;          // Actualizar la cola
        }
    }

    public void MostrarAdelante()
    {
        Nodo actual = cabeza;

        Console.WriteLine("Elementos de cabeza a cola:");
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        }
    }

    public void MostrarAtras()
    {
        Nodo actual = cola;

        Console.WriteLine("Elementos de cola a cabeza:");
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Anterior;
        }
    }
}

class Program
{
    static void Main()
    {
        ListaDobleEnlazada lista = new ListaDobleEnlazada();

        // Agregar elementos a la lista
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);

        // Mostrar elementos en orden normal y en orden inverso
        lista.MostrarAdelante();
        lista.MostrarAtras();
    }
}