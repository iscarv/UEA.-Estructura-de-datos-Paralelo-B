using System;
using System.Collections.Generic;

class RevistaCatalogo
{
    // Método principal que se ejecuta al inicio
    static void Main()
    {
        // Lista que contiene los títulos de revistas en el catálogo
        List<string> catalogo = new List<string>
        {
            "Revista de Ciencia",
            "Tecno Actual",
            "Mundo Digital",
            "Historia Universal",
            "Arte y Cultura",
            "Cocina del Mundo",
            "Salud y Bienestar",
            "Deportes de Hoy",
            "Viajes y Aventuras",
            "Historietas y Entretenimiento"
        };

        // Bucle infinito para seguir mostrando el menú hasta que el usuario decida salir
        while (true)
        {
            // Muestra el menú de opciones
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");

            // Lee la opción seleccionada por el usuario
            string? opcion = Console.ReadLine();

            // Validación para asegurarse de que la opción no sea vacía o nula
            if (string.IsNullOrWhiteSpace(opcion))
            {
                Console.WriteLine("Error: Debe ingresar una opción válida.");
                continue;  // Vuelve a mostrar el menú si la opción no es válida
            }

            // Si el usuario selecciona la opción '2', termina el programa
            if (opcion == "2") break;

            // Si el usuario selecciona una opción diferente de "1" o "2", muestra un error
            if (opcion != "1")
            {
                Console.WriteLine("Error: Opción no válida.");
                continue;  // Vuelve a mostrar el menú
            }

            // Pide al usuario que ingrese el título a buscar
            Console.Write("Ingrese el título a buscar: ");
            string? titulo = Console.ReadLine();

            // Validación para asegurarse de que el título no sea vacío o nulo
            if (string.IsNullOrWhiteSpace(titulo))
            {
                Console.WriteLine("Error: No ingresó un título válido.");
                continue;  // Vuelve a mostrar el menú si el título no es válido
            }

            // Llama a la función de búsqueda iterativa y muestra si el título fue encontrado
            bool encontrado = BusquedaIterativa(catalogo, titulo);
            Console.WriteLine(encontrado ? "Título encontrado" : "Título no encontrado");
        }
    }

    // Función para realizar la búsqueda iterativa del título en el catálogo
    static bool BusquedaIterativa(List<string> catalogo, string titulo)
    {
        // Recorre cada título del catálogo
        foreach (string revista in catalogo)
        {
            // Compara el título ingresado con el título actual de la lista sin distinguir mayúsculas/minúsculas
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true;  // Si encuentra el título, retorna 'true'
            }
        }
        return false;  // Si no encuentra el título en el catálogo, retorna 'false'
    }
}
