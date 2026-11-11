using System;
using System.Windows.Forms;

namespace SistemaClinica
{
    static class Program
    {
        // Punto de entrada de la aplicación de escritorio.
        // [STAThread] es obligatorio en Windows Forms.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var repositorio = new RepositorioClinica();
            Clinica clinica;

            try
            {
                // Crea la base de datos y las tablas si aún no existen,
                // y carga médicos, pacientes y citas guardados.
                repositorio.InicializarBaseDeDatos();
                clinica = repositorio.CargarClinica();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir la base de datos (archivo clinica.db).\n\n" + ex.Message +
                    "\n\nVerifique que la carpeta del programa no sea de solo lectura " +
                    "(por ejemplo, descomprima el .zip antes de ejecutarlo).",
                    "Sistema Clínica", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormPrincipal(repositorio, clinica));
        }
    }
}
