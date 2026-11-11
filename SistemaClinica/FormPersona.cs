using System;
using System.Windows.Forms;

namespace SistemaClinica
{
    // Ventana de diálogo reutilizable para AGREGAR o EDITAR un médico o un paciente.
    // Como ambos heredan de Persona (Id + Nombre), solo cambia el tercer dato:
    // la especialidad (médico) o el teléfono (paciente).
    public partial class FormPersona : Form
    {
        // Función que indica si una cédula ya está registrada (para avisar sin cerrar la ventana).
        private readonly Func<string, bool> cedulaYaExiste;

        // Constructor sin parámetros: solo lo usa el diseñador visual de Visual Studio.
        public FormPersona()
        {
            InitializeComponent();
        }

        public FormPersona(string titulo, string etiquetaDatoExtra, int largoMaximoDatoExtra,
                           Func<string, bool> cedulaYaExiste) : this()
        {
            this.Text = titulo;
            this.lblExtra.Text = etiquetaDatoExtra;
            this.txtExtra.MaxLength = largoMaximoDatoExtra;
            this.cedulaYaExiste = cedulaYaExiste;
        }

        // Datos escritos por el usuario (sin espacios sobrantes).
        public string Cedula { get { return txtId.Text.Trim(); } }
        public string NombreIngresado { get { return txtNombre.Text.Trim(); } }
        public string DatoExtra { get { return txtExtra.Text.Trim(); } }

        // Modo edición: muestra los datos actuales. La cédula no se puede cambiar
        // porque es la clave primaria (la identifica en la base de datos y en sus citas).
        public void CargarDatos(string cedula, string nombre, string datoExtra)
        {
            txtId.Text = cedula;
            txtId.ReadOnly = true;
            txtId.TabStop = false;
            txtNombre.Text = nombre;
            txtExtra.Text = datoExtra;
            this.ActiveControl = txtNombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Cedula.Length == 0)
            {
                Aviso("La cédula / Id es obligatoria.", txtId);
                return;
            }
            if (NombreIngresado.Length == 0)
            {
                Aviso("El nombre es obligatorio.", txtNombre);
                return;
            }
            // Al agregar (no al editar), comprobamos que la cédula no esté repetida.
            if (!txtId.ReadOnly && cedulaYaExiste != null && cedulaYaExiste(Cedula))
            {
                Aviso($"Ya existe un registro con la cédula / Id '{Cedula}'.", txtId);
                return;
            }

            // Cerrar el diálogo indicando que el usuario confirmó.
            this.DialogResult = DialogResult.OK;
        }

        private void Aviso(string mensaje, Control campo)
        {
            MessageBox.Show(this, mensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            campo.Focus();
        }
    }
}
