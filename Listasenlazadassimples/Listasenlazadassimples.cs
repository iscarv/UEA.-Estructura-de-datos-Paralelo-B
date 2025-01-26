using System;

class Nodo
{
    public int Valor;        // Valor del nodo
    public Nodo Siguiente;   // Enlace al siguiente nodo
}

class ListaEnlazada
{
    private Nodo cabeza; // Primer nodo de la lista

    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo();
        nuevoNodo.Valor = valor;
        nuevoNodo.Siguiente = null;

        if (cabeza == null) // Si la lista está vacía
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null) // Buscar el último nodo
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo; // Enlazar el nuevo nodo al final
        }
    }

    public void Mostrar()
    {
        Nodo actual = cabeza;

        if (actual == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.WriteLine("Elementos en la lista:");
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        }
    }
}

class Program
{
    static void Main()
    {
        ListaEnlazada lista = new ListaEnlazada();

        lista.Agregar(1); // Agregar elementos
        lista.Agregar(2);
        lista.Agregar(3);

        lista.Mostrar(); // Mostrar elementos
    }
}