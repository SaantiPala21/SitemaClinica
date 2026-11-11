using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaClinica
{
    // HERENCIA: Con los dos puntos ":" indicamos que Medico hereda todo de Persona.
    // Un Médico "es una" Persona.
    public class Medico : Persona
    {
        // Atributo propio solo de los médicos, encapsulado como 'private'.
        private string especialidad;

        // Propiedad pública para acceder a la especialidad.
        public string Especialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        // Constructor del Médico.
        // 'base(id, nombre)' le envía el id y el nombre directamente al constructor de la clase Padre (Persona)
        // para que ella se encargue de guardarlos, y el Médico solo guarda su especialidad.
        public Medico(string id, string nombre, string especialidad) : base(id, nombre)
        {
            this.especialidad = especialidad;
        }

        // Método que usa la Clínica (Relación de Dependencia / USA).
        public bool VerificarDisponibilidad(DateTime fecha, TimeSpan hora)
        {
            // En un sistema real, aquí buscaríamos en una base de datos si la hora está ocupada.
            // Para simplificar, siempre retornamos 'true' (está disponible).
            return true;
        }
    }
}
