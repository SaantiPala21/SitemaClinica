using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaClinica
{
    public class Cita
    {
        // Identificador de la cita. Lo asigna la base de datos al guardarla
        // (vale 0 mientras la cita no se haya guardado).
        private int id;

        // Atributos básicos encapsulados
        private DateTime fecha;
        private TimeSpan hora;
        private string motivo;
        private string estado;

        // RELACIONES DE ASOCIACIÓN:
        // La Cita "conoce" a un Médico y a un Paciente. Los guarda como atributos.
        private Medico medico;
        private Paciente paciente;

        // RELACIÓN DE COMPOSICIÓN:
        // La historia clínica nace y muere con la cita.
        private HistoriaClinica historia;

        // Getters para permitir que otros lean el estado y los actores de la cita
        public string Estado { get { return estado; } }
        public Paciente Paciente { get { return paciente; } }
        public Medico Medico { get { return medico; } }
        public DateTime Fecha { get { return fecha; } }
        public TimeSpan Hora { get { return hora; } }
        public string Motivo { get { return motivo; } }
        public HistoriaClinica Historia { get { return historia; } }

        // Solo la capa de datos (mismo proyecto: 'internal') puede asignar el Id.
        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }

        // Constructor de uso interno para la capa de datos (RepositorioClinica):
        // reconstruye una cita guardada en la base de datos con su estado e historia tal como estaban.
        internal Cita(int id, DateTime fecha, TimeSpan hora, string motivo, string estado,
                      Medico medico, Paciente paciente, HistoriaClinica historia)
        {
            this.id = id;
            this.fecha = fecha;
            this.hora = hora;
            this.motivo = motivo;
            this.estado = estado;
            this.medico = medico;
            this.paciente = paciente;
            this.historia = historia;
        }

        // Constructor
        public Cita(DateTime fecha, TimeSpan hora, string motivo, Medico medico, Paciente paciente)
        {
            this.fecha = fecha;
            this.hora = hora;
            this.motivo = motivo;
            // Toda cita nace en estado "PROGRAMADA" por defecto.
            this.estado = "PROGRAMADA";

            // Asignamos las asociaciones
            this.medico = medico;
            this.paciente = paciente;

            // Nota: No creamos la HistoriaClinica aquí porque la cita apenas se está programando (0..1).
        }

        // Método para cancelar.
        // REGLA DE NEGOCIO: Solo una cita PROGRAMADA puede cancelarse
        // (no se cancela una cita ya atendida ni una ya cancelada).
        // Devuelve true si el cambio de estado se realizó.
        public bool CancelarCita()
        {
            if (this.estado != "PROGRAMADA")
            {
                Console.WriteLine($"Error: No se puede cancelar. La cita está {this.estado}.");
                return false;
            }

            this.estado = "CANCELADA";
            Console.WriteLine("Cita cancelada con éxito.");
            return true;
        }

        // Método principal de atención.
        // REGLA DE NEGOCIO: Solo una cita PROGRAMADA puede atenderse. Así evitamos
        // atender una cita cancelada o volver a atender una ya atendida
        // (lo que sobrescribiría y perdería su historia clínica).
        // Devuelve true si el cambio de estado se realizó.
        public bool AtenderCita(string resumen)
        {
            if (this.estado != "PROGRAMADA")
            {
                Console.WriteLine($"Error: No se puede atender. La cita está {this.estado}.");
                return false;
            }

            // Cambiamos el estado
            this.estado = "ATENDIDA";

            // COMPOSICIÓN EN ACCIÓN: Al atender, instanciamos (creamos) la historia clínica
            // pasándole el resumen médico. Ahora la multiplicidad pasa de 0 a 1.
            this.historia = new HistoriaClinica(resumen);
            Console.WriteLine("Cita ATENDIDA. " + this.historia.MostrarResumen());
            return true;
        }

        // Método auxiliar para imprimir los datos en la consola
        public void MostrarInfo()
        {
            Console.WriteLine($"Fecha: {fecha.ToShortDateString()} | Hora: {hora} | Paciente: {paciente.Nombre} | Doc: {medico.Nombre} | Estado: {estado}");
        }
    }
}