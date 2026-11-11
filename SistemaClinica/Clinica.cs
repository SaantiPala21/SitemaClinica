using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClinica
{
    public class Clinica
    {
        // RELACIONES DE AGREGACIÓN Y COMPOSICIÓN:
        // Listas (colecciones) que guardan objetos de otras clases (multiplicidad 0..*).
        private List<Medico> listaMedicos;
        private List<Paciente> listaPacientes;
        private List<Cita> listaCitas;

        // Constructor de la clínica: Inicializa las listas vacías para que no den error al usarlas.
        public Clinica()
        {
            listaMedicos = new List<Medico>();
            listaPacientes = new List<Paciente>();
            listaCitas = new List<Cita>();
        }

        // Vistas de solo lectura de las listas, para que la interfaz gráfica pueda mostrarlas
        // sin poder agregar ni quitar elementos por fuera de los métodos de la clínica.
        public IReadOnlyList<Medico> Medicos { get { return listaMedicos.AsReadOnly(); } }
        public IReadOnlyList<Paciente> Pacientes { get { return listaPacientes.AsReadOnly(); } }
        public IReadOnlyList<Cita> Citas { get { return listaCitas.AsReadOnly(); } }

        // Uso interno de la capa de datos: agrega una cita que ya existía en la base de datos
        // (no pasa por AgendarCita porque no es una cita nueva).
        internal void CargarCita(Cita cita)
        {
            listaCitas.Add(cita);
        }

        // Métodos para agregar elementos a las listas
        public void RegistrarMedico(Medico medico)
        {
            listaMedicos.Add(medico);
        }

        public void RegistrarPaciente(Paciente paciente)
        {
            listaPacientes.Add(paciente);
        }

        // Métodos para eliminar elementos de las listas.
        // REGLA DE NEGOCIO: no se puede eliminar un médico o paciente que tenga citas,
        // porque esas citas quedarían sin médico/paciente. Devuelven true si se eliminó.
        public bool EliminarMedico(Medico medico)
        {
            if (listaCitas.Any(c => c.Medico == medico))
                return false;
            return listaMedicos.Remove(medico);
        }

        public bool EliminarPaciente(Paciente paciente)
        {
            if (listaCitas.Any(c => c.Paciente == paciente))
                return false;
            return listaPacientes.Remove(paciente);
        }

        // Método principal de negocio.
        // Devuelve la Cita creada (para poder atenderla o cancelarla después),
        // o null si no se pudo agendar.
        public Cita AgendarCita(Paciente paciente, Medico medico, DateTime fecha, TimeSpan hora, string motivo)
        {
            // RELACIÓN DEPENDENCIA (USA): La Clínica necesita invocar un método del Médico
            // para poder continuar con su proceso.
            if (medico.VerificarDisponibilidad(fecha, hora))
            {
                // Si el médico está libre, creamos el objeto Cita
                Cita nuevaCita = new Cita(fecha, hora, motivo, medico, paciente);

                // Guardamos la cita en la lista de la clínica (Composición)
                listaCitas.Add(nuevaCita);
                Console.WriteLine("Cita agendada correctamente.");
                return nuevaCita;
            }

            // Si el médico da 'false', bloqueamos el proceso.
            Console.WriteLine("El médico no tiene agenda disponible.");
            return null;
        }

        // Recorre la lista de citas y manda a imprimir cada una
        public void MostrarCitas()
        {
            Console.WriteLine("\n--- AGENDA DE LA CLÍNICA ---");
            // Un ciclo foreach para recorrer la listaCitas uno por uno
            foreach (var cita in listaCitas)
            {
                cita.MostrarInfo(); // Ejecuta el método de la clase Cita
            }
            Console.WriteLine("----------------------------\n");
        }
    }
}
