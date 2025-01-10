using System;
using System.Collections.Generic;

namespace ClinicaTurnos
{
    // Estructura para representar un paciente
    struct Paciente
    {
        // Propiedades de la estructura
        public int ID { get; set; } // Identificador único del paciente
        public string Nombre { get; set; } // Nombre del paciente
        public string Especialidad { get; set; } // Especialidad médica del turno
        public DateTime FechaTurno { get; set; } // Fecha y hora del turno

        // Constructor para inicializar los valores de un paciente
        public Paciente(int id, string nombre, string especialidad, DateTime fechaTurno)
        {
            ID = id;
            Nombre = nombre;
            Especialidad = especialidad;
            FechaTurno = fechaTurno;
        }

        // Sobrescritura del método ToString para una representación personalizada del paciente
        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre}, Especialidad: {Especialidad}, Fecha del Turno: {FechaTurno:dd/MM/yyyy HH:mm}";
        }
    }

    // Clase para gestionar la agenda de turnos
    class AgendaTurnos
    {
        // Lista para almacenar los turnos de los pacientes
        private List<Paciente> pacientes;

        // Constructor para inicializar la lista de pacientes
        public AgendaTurnos()
        {
            pacientes = new List<Paciente>();
        }

        // Método para agregar un nuevo turno a la agenda
        public void AgregarTurno(Paciente paciente)
        {
            pacientes.Add(paciente); // Agregar paciente a la lista
            Console.WriteLine("Turno agregado exitosamente."); // Mensaje de confirmación
        }

        // Método para eliminar un turno de la agenda por ID
        public void EliminarTurno(int id)
        {
            // Buscar el paciente por su ID
            Paciente paciente = pacientes.Find(p => p.ID == id);

            // Verificar si el paciente no existe en la lista
            if (paciente.Equals(default(Paciente)))
            {
                Console.WriteLine("Paciente no encontrado."); // Mensaje de error
            }
            else
            {
                pacientes.Remove(paciente); // Eliminar paciente de la lista
                Console.WriteLine("Turno eliminado exitosamente."); // Mensaje de confirmación
            }
        }

        // Método para consultar y mostrar todos los turnos registrados
        public void ConsultarTurnos()
        {
            Console.WriteLine("\n--- Lista de Turnos ---");

            // Verificar si no hay turnos registrados
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados."); // Mensaje de aviso
                return;
            }

            // Mostrar la información de cada paciente
            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        // Método para buscar turnos por especialidad médica
        public void BuscarTurnoPorEspecialidad(string especialidad)
        {
            Console.WriteLine($"\n--- Turnos para {especialidad} ---");

            // Filtrar turnos que coincidan con la especialidad buscada (sin distinción de mayúsculas/minúsculas)
            var turnos = pacientes.FindAll(p => p.Especialidad.Equals(especialidad, StringComparison.OrdinalIgnoreCase));

            // Verificar si no se encontraron turnos para la especialidad
            if (turnos.Count == 0)
            {
                Console.WriteLine($"No se encontraron turnos para la especialidad: {especialidad}");
                return;
            }

            // Mostrar la información de cada paciente encontrado
            foreach (var paciente in turnos)
            {
                Console.WriteLine(paciente);
            }
        }
    }

    // Clase principal que contiene el método de entrada del programa
    class Program
    {
        // Método Main, punto de entrada del programa
        static void Main(string[] args)
        {
            // Crear una instancia de la clase AgendaTurnos
            AgendaTurnos agenda = new AgendaTurnos();

            // Agregar pacientes con turnos predefinidos
            agenda.AgregarTurno(new Paciente(1, "Lucas Ramirez", "Cardiología", new DateTime(2025, 1, 15, 10, 0, 0)));
            agenda.AgregarTurno(new Paciente(2, "María López", "Dermatología", new DateTime(2025, 1, 20, 14, 0, 0)));
            agenda.AgregarTurno(new Paciente(3, "David Casas", "Cardiología", new DateTime(2025, 1, 22, 9, 30, 0)));

            // Consultar y mostrar todos los turnos
            agenda.ConsultarTurnos();

            // Buscar y mostrar turnos para la especialidad "Cardiología"
            agenda.BuscarTurnoPorEspecialidad("Cardiología");

            // Eliminar un turno por ID
            agenda.EliminarTurno(2);

            // Consultar nuevamente para verificar los cambios
            agenda.ConsultarTurnos();
        }
    }
}