using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SistemaClinica
{
    public class HistoriaClinica
    {
        // Encapsulamiento estricto: Todo privado.
        private DateTime fechaGeneracion;
        private string resumen;

        // Constructor. Se ejecuta automáticamente al hacer 'new HistoriaClinica(...)'.
        public HistoriaClinica(string resumen)
        {
            // DateTime.Now captura la fecha y hora exacta de la computadora en este mismo instante.
            this.fechaGeneracion = DateTime.Now;
            this.resumen = resumen;
        }

        // Constructor de uso interno para la capa de datos (RepositorioClinica):
        // reconstruye una historia que ya existía en la base de datos, conservando su fecha original.
        internal HistoriaClinica(DateTime fechaGeneracion, string resumen)
        {
            this.fechaGeneracion = fechaGeneracion;
            this.resumen = resumen;
        }

        // Propiedades de solo lectura (sin 'set'): se pueden consultar pero no modificar.
        public DateTime FechaGeneracion { get { return fechaGeneracion; } }
        public string Resumen { get { return resumen; } }

        // Método para devolver la información estructurada sin permitir que se modifique.
        public string MostrarResumen()
        {
            return $"[Historia de {fechaGeneracion.ToShortDateString()}] {resumen}";
        }
    }
}