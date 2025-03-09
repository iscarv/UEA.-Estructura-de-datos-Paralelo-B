using System;
using System.Collections.Generic;

class PremiacionDeportistas
{
    // Conjunto para almacenar disciplinas sin duplicados
    static HashSet<string> disciplinas = new HashSet<string>();

    // Diccionario para almacenar deportistas con su disciplina y premio
    static Dictionary<string, (string disciplina, string premio)> deportistas = new Dictionary<string, (string, string)>();

    static void Main()
    {
        int opcion;
        do
        {
            Console.Clear();
            Console.WriteLine("=== Premiación de Deportistas ===");
            Console.WriteLine("1. Registrar disciplina");
            Console.WriteLine("2. Registrar deportista");
            Console.WriteLine("3. Asignar premio");
            Console.WriteLine("4. Consultar deportistas por disciplina");
            Console.WriteLine("5. Generar reporte");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            
            // Intentamos convertir la entrada en un número entero
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Ingrese un número válido.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    RegistrarDisciplina();
                    break;
                case 2:
                    RegistrarDeportista();
                    break;
                case 3:
                    AsignarPremio();
                    break;
                case 4:
                    ConsultarDeportistasPorDisciplina();
                    break;
                case 5:
                    GenerarReporte();
                    break;
                case 6:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
        } while (opcion != 6);
    }

    // Método para registrar una nueva disciplina
    static void RegistrarDisciplina()
    {
        Console.Write("Ingrese el nombre de la disciplina: ");
        string disciplina = Console.ReadLine();

        // Se usa un HashSet para evitar duplicados
        if (disciplinas.Add(disciplina))
            Console.WriteLine("Disciplina registrada correctamente.");
        else
            Console.WriteLine("La disciplina ya existe.");

        Console.ReadKey();
    }

    // Método para registrar un deportista en una disciplina
    static void RegistrarDeportista()
    {
        Console.Write("Ingrese el nombre del deportista: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese la disciplina del deportista: ");
        string disciplina = Console.ReadLine();

        // Validamos que la disciplina exista antes de asignarla al deportista
        if (!disciplinas.Contains(disciplina))
        {
            Console.WriteLine("La disciplina no está registrada. Regístrela primero.");
        }
        else if (deportistas.ContainsKey(nombre))
        {
            Console.WriteLine("El deportista ya está registrado.");
        }
        else
        {
            // Se registra el deportista con la disciplina, inicialmente sin premio
            deportistas[nombre] = (disciplina, "Sin premio");
            Console.WriteLine("Deportista registrado correctamente.");
        }

        Console.ReadKey();
    }

    // Método para asignar un premio a un deportista
    static void AsignarPremio()
    {
        Console.Write("Ingrese el nombre del deportista: ");
        string nombre = Console.ReadLine();

        // Verificamos si el deportista está registrado
        if (deportistas.ContainsKey(nombre))
        {
            Console.Write("Ingrese el premio otorgado: ");
            string premio = Console.ReadLine();

            // Actualizamos el premio del deportista en el diccionario
            deportistas[nombre] = (deportistas[nombre].disciplina, premio);
            Console.WriteLine("Premio asignado correctamente.");
        }
        else
        {
            Console.WriteLine("El deportista no está registrado.");
        }

        Console.ReadKey();
    }

    // Método para consultar los deportistas de una disciplina específica
    static void ConsultarDeportistasPorDisciplina()
    {
        Console.Write("Ingrese la disciplina a consultar: ");
        string disciplina = Console.ReadLine();

        Console.WriteLine($"=== Deportistas en {disciplina} ===");

        bool encontrado = false;
        foreach (var kvp in deportistas)
        {
            if (kvp.Value.disciplina == disciplina)
            {
                Console.WriteLine($"- {kvp.Key} ({kvp.Value.premio})");
                encontrado = true;
            }
        }

        if (!encontrado)
            Console.WriteLine("No hay deportistas registrados en esta disciplina.");

        Console.ReadKey();
    }

    // Método para generar un reporte de todos los deportistas y sus premios
    static void GenerarReporte()
    {
        Console.WriteLine("=== Reporte de Deportistas y Premios ===");

        if (deportistas.Count == 0)
        {
            Console.WriteLine("No hay deportistas registrados.");
        }
        else
        {
            foreach (var kvp in deportistas)
            {
                Console.WriteLine($"{kvp.Key} - Disciplina: {kvp.Value.disciplina} - Premio: {kvp.Value.premio}");
            }
        }

        Console.ReadKey();
    }
}
