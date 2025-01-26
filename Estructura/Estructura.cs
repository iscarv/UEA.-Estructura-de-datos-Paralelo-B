using System;

struct Libro
{
    // Miembros de la estructura
    public string Titulo;
    public string Autor;
    public int AñoDePublicacion;

    // Método para mostrar la información del libro
    public void MostrarInfo()
    {
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Año de Publicación: {AñoDePublicacion}");
    }
}

class Program
{
    static void Main()
    {
        // Crear una instancia de la estructura Libro
        Libro libro1 = new Libro();
        
        // Asignar valores a los miembros de la estructura
        libro1.Titulo = "Cien años de soledad";
        libro1.Autor = "Gabriel García Márquez";
        libro1.AñoDePublicacion = 1967;

        // Mostrar la información del libro
        libro1.MostrarInfo();
    }
}
