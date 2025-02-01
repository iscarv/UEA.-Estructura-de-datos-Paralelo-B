using System;
using System.Collections.Generic;

// Clase que representa la atracción y la gestión de asientos
class Atraccion
{
    private const int Capacidad = 30; // Número máximo de asientos disponibles en la atracción
    private Queue<string> colaEspera = new Queue<string>(); // Cola para personas en lista de espera
    private List<string> asientos = new List<string>(); // Lista de asientos ocupados

    // Método para agregar una persona a la atracción o a la lista de espera
    public void AgregarPersona(string nombre)
    {
        if (asientos.Count < Capacidad)
        {
            asientos.Add(nombre);
            Console.WriteLine($"{nombre} ha recibido un asiento.");
        }
        else
        {
            colaEspera.Enqueue(nombre);
            Console.WriteLine($"{nombre} ha sido agregado a la lista de espera.");
        }
    }

    // Método para mostrar los asientos ocupados
    public void MostrarAsientos()
    {
        Console.WriteLine("\nEstado de los asientos:");
        if (asientos.Count == 0)
        {
            Console.WriteLine("No hay asientos ocupados.");
        }
        else
        {
            for (int i = 0; i < asientos.Count; i++)
            {
                Console.WriteLine($"Asiento {i + 1}: {asientos[i]}");
            }
        }
    }

    // Método para mostrar la lista de espera
    public void MostrarColaEspera()
    {
        Console.WriteLine("\nPersonas en lista de espera:");
        if (colaEspera.Count == 0)
        {
            Console.WriteLine("No hay nadie en la lista de espera.");
        }
        else
        {
            foreach (var persona in colaEspera)
            {
                Console.WriteLine(persona);
            }
        }
    }

    // Métodos de consulta

    // Consultar si una persona tiene un asiento asignado
    public void ConsultarAsiento(string nombre)
    {
        if (asientos.Contains(nombre))
        {
            int asiento = asientos.IndexOf(nombre) + 1;
            Console.WriteLine($"{nombre} tiene el asiento número {asiento}.");
        }
        else
        {
            Console.WriteLine($"{nombre} no tiene un asiento asignado.");
        }
    }

    // Consultar si una persona está en la lista de espera
    public void ConsultarListaEspera(string nombre)
    {
        if (colaEspera.Contains(nombre))
        {
            Console.WriteLine($"{nombre} está en la lista de espera.");
        }
        else
        {
            Console.WriteLine($"{nombre} no está en la lista de espera.");
        }
    }

    // Consultar cuántos asientos quedan disponibles
    public void ConsultarAsientosDisponibles()
    {
        int disponibles = Capacidad - asientos.Count;
        Console.WriteLine($"\nAsientos disponibles: {disponibles} de {Capacidad}");
    }
}

// Clase principal que ejecuta el programa
class Program
{
    static void Main()
    {
        Atraccion atraccion = new Atraccion(); // Crea una instancia de la atracción

        // Simula la llegada de 35 personas
        for (int i = 1; i <= 35; i++)
        {
            atraccion.AgregarPersona($"Persona {i}");
        }

        // Mostrar estado de los asientos y la lista de espera
        atraccion.MostrarAsientos();
        atraccion.MostrarColaEspera();
        atraccion.ConsultarAsientosDisponibles();

        // Pruebas de consulta 
        Console.WriteLine("\n Consultas:");
        atraccion.ConsultarAsiento("Persona 10"); // Debe tener un asiento
        atraccion.ConsultarAsiento("Persona 31"); // No tiene asiento

        atraccion.ConsultarListaEspera("Persona 31"); // Debe estar en la lista de espera
        atraccion.ConsultarListaEspera("Persona 5");  // No debe estar en la lista de espera
    }
}