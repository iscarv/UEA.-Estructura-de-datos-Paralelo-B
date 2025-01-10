using System;
using System.Collections.Generic;

namespace ClinicaTurnos
{
    // Estructura para representar un paciente
    struct Paciente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } 
        public string Especialidad { get; set; } 
        public DateTime FechaTurno { get; set; }

        // Constructor de la estructura
        public Paciente(int id, string nombre, string especialidad, DateTime fechaTurno)
        {
            ID = id;
            Nombre = nombre;
            Especialidad = especialidad;
            FechaTurno = fechaTurno;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre}, Especialidad: {Especialidad}, Fecha del Turno: {FechaTurno:dd/MM/yyyy HH:mm}";
        }
    }

    // Clase para gestionar la agenda de turnos
    class AgendaTurnos
    {
        private List<Paciente> pacientes;

        public AgendaTurnos()
        {
            pacientes = new List<Paciente>();
        }

        public void AgregarTurno(Paciente paciente)
        {
            pacientes.Add(paciente);
            Console.WriteLine("Turno agregado exitosamente.");
        }

        public void EliminarTurno(int id)
        {
            Paciente paciente = pacientes.Find(p => p.ID == id);
            if (paciente.Equals(default(Paciente)))
            {
                Console.WriteLine("Paciente no encontrado.");
            }
            else
            {
                pacientes.Remove(paciente);
                Console.WriteLine("Turno eliminado exitosamente.");
            }
        }

        public void ConsultarTurnos()
        {
            Console.WriteLine("\n--- Lista de Turnos ---");
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay turnos registrados.");
                return;
            }

            foreach (var paciente in pacientes)
            {
                Console.WriteLine(paciente);
            }
        }

        public void BuscarTurnoPorEspecialidad(string especialidad)
        {
            Console.WriteLine($"\n--- Turnos para {especialidad} ---");
            var turnos = pacientes.FindAll(p => p.Especialidad.Equals(especialidad, StringComparison.OrdinalIgnoreCase));

            if (turnos.Count == 0)
            {
                Console.WriteLine($"No se encontraron turnos para la especialidad: {especialidad}");
                return;
            }

            foreach (var paciente in turnos)
            {
                Console.WriteLine(paciente);
            }
        }
    }

    // Programa principal
    class Program
    {
        static void Main(string[] args)
        {
            AgendaTurnos agenda = new AgendaTurnos();

            // Agregar pacientes con el constructor de DateTime corregido
            agenda.AgregarTurno(new Paciente(1, "Lucas Ramirez", "Cardiología", new DateTime(2025, 1, 15, 10, 0, 0)));
            agenda.AgregarTurno(new Paciente(2, "María López", "Dermatología", new DateTime(2025, 1, 20, 14, 0, 0)));
            agenda.AgregarTurno(new Paciente(3, "David Casas", "Cardiología", new DateTime(2025, 1, 22, 9, 30, 0)));

            // Consultar turnos
            agenda.ConsultarTurnos();

            // Buscar turnos por especialidad
            agenda.BuscarTurnoPorEspecialidad("Cardiología");

            // Eliminar un turno
            agenda.EliminarTurno(2);

            // Consultar turnos nuevamente
            agenda.ConsultarTurnos();
        }
    }
}