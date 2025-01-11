// Ejercicio2. Escribir un programa que almacene las asignaturas de un curso (por ejemplo 
//Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla el mensaje 
//Yo estudio <asignatura>, donde <asignatura> es cada una de las asignaturas de la lista.
using System;
using System.Collections.Generic;

namespace CursoAsignaturas
{
    // Clase que representa una asignatura
    public class Asignatura
    {
        // Propiedad que almacena el nombre de la asignatura
        public string Nombre { get; set; }

        // Constructor que inicializa el nombre de la asignatura
        public Asignatura(string nombre)
        {
            Nombre = nombre;  // Asigna el nombre de la asignatura al atributo
        }
    }

    // Clase que representa un curso, compuesto por varias asignaturas
    public class Curso
    {
        // Lista privada que contiene las asignaturas del curso
        private List<Asignatura> Asignaturas { get; set; }

        // Constructor que inicializa la lista de asignaturas vacía
        public Curso()
        {
            Asignaturas = new List<Asignatura>();  // Inicializa la lista para almacenar asignaturas
        }

        // Método para agregar una nueva asignatura al curso
        public void AgregarAsignatura(string nombre)
        {
            // Crea una nueva asignatura y la agrega a la lista
            Asignaturas.Add(new Asignatura(nombre));
        }

        // Método para mostrar todas las asignaturas con un mensaje personalizado
        public void MostrarAsignaturas()
        {
            // Recorre la lista de asignaturas y muestra un mensaje por cada una
            foreach (var asignatura in Asignaturas)
            {
                // Muestra en consola el mensaje "Yo estudio <nombre de la asignatura>"
                Console.WriteLine($"Yo estudio {asignatura.Nombre}");
            }
        }
    }

    // Clase que contiene el punto de entrada del programa
    class Program
    {
        static void Main(string[] args)
        {
            // Crea una nueva instancia del curso
            Curso curso = new Curso();

            // Agrega las asignaturas al curso usando el método AgregarAsignatura
            curso.AgregarAsignatura("Matemáticas");
            curso.AgregarAsignatura("Física");
            curso.AgregarAsignatura("Química");
            curso.AgregarAsignatura("Historia");
            curso.AgregarAsignatura("Lengua");

            // Muestra todas las asignaturas del curso con el mensaje "Yo estudio ..."
            curso.MostrarAsignaturas();

            // Pausa la ejecución para que el usuario pueda ver el resultado
            Console.ReadLine();
        }
    }
}