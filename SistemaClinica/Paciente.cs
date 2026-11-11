using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaClinica
{
    // HERENCIA: Paciente también hereda de Persona.
    public class Paciente : Persona
    {
        // Atributo propio del paciente.
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        // Constructor que delega id y nombre a la clase Padre usando 'base'.
        public Paciente(string id, string nombre, string telefono) : base(id, nombre)
        {
            this.telefono = telefono;
        }

        // Comportamientos básicos del paciente según el diagrama UML.
        public void SolicitarCita()
        {
            Console.WriteLine($"El paciente {nombre} solicita una cita.");
        }

        public void CancelarCita()
        {
            Console.WriteLine($"El paciente {nombre} solicita cancelar su cita.");
        }
    }
}
