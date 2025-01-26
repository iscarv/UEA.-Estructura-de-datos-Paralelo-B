using System;

class Program
{
    // Definición de un registro simple
    public record Persona(string Nombre, int Edad);

    static void Main(string[] args)
    {
        // Crear una instancia del registro
        Persona persona1 = new Persona("Carlos", 28);

        // Mostrar los valores del registro
        Console.WriteLine($"Nombre: {persona1.Nombre}, Edad: {persona1.Edad}");
        
        // Crear una copia modificada del registro
        Persona persona2 = persona1 with { Edad = 30 };

        // Mostrar la copia modificada
        Console.WriteLine($"Nombre: {persona2.Nombre}, Edad: {persona2.Edad}");
    }
}
