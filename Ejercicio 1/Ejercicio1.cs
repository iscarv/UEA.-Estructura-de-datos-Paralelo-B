// Ejercicio1. Escribir un programa que almacene las asignaturas de un curso
//(por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla.
using System;
using System.Collections.Generic;

namespace CursoAsignaturas
{
    public class Program
    {
        // Método Main explícito como punto de entrada
        public static void Main(string[] args)
        {
            // Crea una instancia de la clase Curso
            Curso curso = new Curso();

            // Agrega asignaturas al curso
            curso.AgregarAsignatura("Matemáticas");
            curso.AgregarAsignatura("Física");
            curso.AgregarAsignatura("Química");
            curso.AgregarAsignatura("Historia");
            curso.AgregarAsignatura("Lengua");

            // Muestra las asignaturas del curso
            curso.MostrarAsignaturas();

            // Pausa para leer el resultado
            Console.ReadLine();
        }
    }

    // Clase que representa una asignatura
    public class Asignatura
    {
        public string Nombre { get; set; } // Propiedad para el nombre de la asignatura

        // Constructor que inicializa la asignatura con su nombre
        public Asignatura(string nombre)
        {
            Nombre = nombre;
        }

        // Sobrescribe ToString para devolver el nombre de la asignatura
        public override string ToString()
        {
            return Nombre;
        }
    }

    // Clase que representa un curso con varias asignaturas
    public class Curso
    {
        public List<Asignatura> Asignaturas { get; private set; }

        // Constructor que inicializa la lista de asignaturas
        public Curso()
        {
            Asignaturas = new List<Asignatura>();
        }

        // Método para agregar una asignatura
        public void AgregarAsignatura(string nombre)
        {
            Asignaturas.Add(new Asignatura(nombre));
        }

        // Método para mostrar todas las asignaturas
        public void MostrarAsignaturas()
        {
            Console.WriteLine("Asignaturas del curso:");
            foreach (var asignatura in Asignaturas)
            {
                Console.WriteLine($"- {asignatura}");
            }
        }
    }
}