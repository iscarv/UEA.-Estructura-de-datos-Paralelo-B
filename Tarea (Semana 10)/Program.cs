using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CampañaVacunaciónCOVID
{
    // Cambié el nombre de la clase de "Program" a "ReportGenerator"
    // para evitar conflictos si hay otra clase "Program" en el proyecto.
    class ReportGenerator
    {
        // Método principal de la aplicación
        static void Main()
        {
            // Paso 1: Generar un conjunto de 500 ciudadanos ficticios
            var todosLosCiudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                todosLosCiudadanos.Add($"Ciudadano {i}");
            }

            // Paso 2: Generar un conjunto de 75 ciudadanos vacunados con Pfizer
            var vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add($"Ciudadano {i}");
            }

            // Paso 3: Generar un conjunto de 75 ciudadanos vacunados con AstraZeneca
            var vacunadosAstrazeneca = new HashSet<string>();
            for (int i = 76; i <= 150; i++)
            {
                vacunadosAstrazeneca.Add($"Ciudadano {i}");
            }

            // Paso 4: Calcular ciudadanos que han recibido ambas vacunas (intersección)
            var vacunadosAmbas = new HashSet<string>(vacunadosPfizer.Intersect(vacunadosAstrazeneca));

            // Paso 5: Calcular ciudadanos que solo han recibido la vacuna de Pfizer (diferencia)
            var soloPfizer = new HashSet<string>(vacunadosPfizer.Except(vacunadosAstrazeneca));

            // Paso 6: Calcular ciudadanos que solo han recibido la vacuna de AstraZeneca (diferencia)
            var soloAstrazeneca = new HashSet<string>(vacunadosAstrazeneca.Except(vacunadosPfizer));

            // Paso 7: Calcular ciudadanos que no han sido vacunados (diferencia con la unión de ambos conjuntos)
            var noVacunados = new HashSet<string>(todosLosCiudadanos.Except(vacunadosPfizer.Union(vacunadosAstrazeneca)));

            // Paso 8: Generar reportes en archivos de texto
            GenerarReporte("Listado_No_Vacunados.txt", noVacunados);
            GenerarReporte("Listado_Vacunados_Ambas.txt", vacunadosAmbas);
            GenerarReporte("Listado_Solo_Pfizer.txt", soloPfizer);
            GenerarReporte("Listado_Solo_Astrazeneca.txt", soloAstrazeneca);

            Console.WriteLine("Reportes generados con éxito.");
        }

        // Método para generar reportes en archivos de texto
        static void GenerarReporte(string nombreArchivo, HashSet<string> datos)
        {
            // Usamos StreamWriter para escribir los datos en el archivo especificado
            using (var escritor = new StreamWriter(nombreArchivo))
            {
                foreach (var item in datos)
                {
                    escritor.WriteLine(item); // Escribimos cada ciudadano en una nueva línea
                }
            }
        }
    }
}