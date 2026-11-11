using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaClinica
{
    // Esta es la "Clase Padre" o "Superclase". 
    // Agrupa los atributos que tienen en común Médicos y Pacientes para no repetir código.
    public class Persona
    {
        // ENCAPSULAMIENTO: Usamos 'protected' para que estos atributos estén ocultos al público,
        // pero permitimos que las clases "hijas" (Medico y Paciente) sí puedan usarlos.
        protected string id;
        protected string nombre;

        // Propiedades públicas (Getters y Setters). 
        // Son la "puerta de acceso" controlada para leer (get) o modificar (set) los atributos protegidos.
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        // Constructor: Es el método especial que se ejecuta al crear (instanciar) un nuevo objeto.
        // Pide los datos iniciales obligatorios.
        public Persona(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
