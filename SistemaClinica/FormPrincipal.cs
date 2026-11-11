using System;
using System.Linq;
using System.Windows.Forms;

namespace SistemaClinica
{
    // INTERFAZ GRÁFICA (Windows Forms).
    // El formulario solo se encarga de leer lo que escribe el usuario y mostrar resultados.
    // Las reglas de negocio siguen en las clases del modelo (Clinica, Cita...) y
    // el guardado en la base de datos lo hace RepositorioClinica.
    public partial class FormPrincipal : Form
    {
        private readonly RepositorioClinica repositorio;
        private Clinica clinica;

        // Constructor sin parámetros: solo lo usa el diseñador visual de Visual Studio.
        public FormPrincipal()
        {
            InitializeComponent();
        }

        public FormPrincipal(RepositorioClinica repositorio, Clinica clinica) : this()
        {
            this.repositorio = repositorio;
            this.clinica = clinica;

            // Por defecto proponemos agendar para mañana a las 8:00.
            dtpFecha.Value = DateTime.Today.AddDays(1);
            dtpHora.Value = DateTime.Today.AddHours(8);

            RefrescarPantalla();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        // =================================================================
        //  MÉDICOS: agregar, editar, eliminar
        // =================================================================

        // Lo usan el botón "Agregar médico", el menú Registrar y el botón "+" de la pestaña Citas.
        private void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            using (var dialogo = new FormPersona("Nuevo médico", "Especialidad:", 100,
                       cedula => clinica.Medicos.Any(m => MismaCedula(m, cedula))))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                var medico = new Medico(dialogo.Cedula, dialogo.NombreIngresado, dialogo.DatoExtra);

                // Primero se guarda en la base de datos; si falla, no se agrega a la clínica en memoria.
                bool guardado = EjecutarEnBaseDeDatos(() =>
                {
                    repositorio.GuardarMedico(medico);
                    clinica.RegistrarMedico(medico);
                });

                if (guardado)
                {
                    RefrescarPantalla();
                    // Dejamos el nuevo médico seleccionado en la lista y en el combo de citas.
                    SeleccionarFila(dgvMedicos, medico);
                    cmbMedico.SelectedItem = medico;
                }
            }
        }

        private void btnEditarMedico_Click(object sender, EventArgs e)
        {
            var medico = FilaSeleccionada(dgvMedicos) as Medico;
            if (medico == null)
            {
                Aviso("Seleccione un médico de la lista.");
                return;
            }

            using (var dialogo = new FormPersona("Editar médico", "Especialidad:", 100, null))
            {
                dialogo.CargarDatos(medico.Id, medico.Nombre, medico.Especialidad);
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                medico.Nombre = dialogo.NombreIngresado;
                medico.Especialidad = dialogo.DatoExtra;

                if (EjecutarEnBaseDeDatos(() => repositorio.ActualizarMedico(medico)))
                {
                    RefrescarPantalla();
                    SeleccionarFila(dgvMedicos, medico);
                }
            }
        }

        private void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            var medico = FilaSeleccionada(dgvMedicos) as Medico;
            if (medico == null)
            {
                Aviso("Seleccione un médico de la lista.");
                return;
            }
            if (!Confirmar($"¿Eliminar al médico {medico.Nombre} ({medico.Id})?"))
                return;

            // REGLA DE NEGOCIO (en la clase Clinica): no se elimina si tiene citas.
            if (!clinica.EliminarMedico(medico))
            {
                Aviso($"No se puede eliminar a {medico.Nombre} porque tiene citas registradas.");
                return;
            }

            if (EjecutarEnBaseDeDatos(() => repositorio.EliminarMedico(medico)))
                RefrescarPantalla();
        }

        private void dgvMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarMedico_Click(sender, e);
        }

        // =================================================================
        //  PACIENTES: agregar, editar, eliminar
        // =================================================================

        // Lo usan el botón "Agregar paciente", el menú Registrar y el botón "+" de la pestaña Citas.
        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            using (var dialogo = new FormPersona("Nuevo paciente", "Teléfono:", 30,
                       cedula => clinica.Pacientes.Any(p => MismaCedula(p, cedula))))
            {
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                var paciente = new Paciente(dialogo.Cedula, dialogo.NombreIngresado, dialogo.DatoExtra);

                bool guardado = EjecutarEnBaseDeDatos(() =>
                {
                    repositorio.GuardarPaciente(paciente);
                    clinica.RegistrarPaciente(paciente);
                });

                if (guardado)
                {
                    RefrescarPantalla();
                    SeleccionarFila(dgvPacientes, paciente);
                    cmbPaciente.SelectedItem = paciente;
                }
            }
        }

        private void btnEditarPaciente_Click(object sender, EventArgs e)
        {
            var paciente = FilaSeleccionada(dgvPacientes) as Paciente;
            if (paciente == null)
            {
                Aviso("Seleccione un paciente de la lista.");
                return;
            }

            using (var dialogo = new FormPersona("Editar paciente", "Teléfono:", 30, null))
            {
                dialogo.CargarDatos(paciente.Id, paciente.Nombre, paciente.Telefono);
                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                paciente.Nombre = dialogo.NombreIngresado;
                paciente.Telefono = dialogo.DatoExtra;

                if (EjecutarEnBaseDeDatos(() => repositorio.ActualizarPaciente(paciente)))
                {
                    RefrescarPantalla();
                    SeleccionarFila(dgvPacientes, paciente);
                }
            }
        }

        private void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            var paciente = FilaSeleccionada(dgvPacientes) as Paciente;
            if (paciente == null)
            {
                Aviso("Seleccione un paciente de la lista.");
                return;
            }
            if (!Confirmar($"¿Eliminar al paciente {paciente.Nombre} ({paciente.Id})?"))
                return;

            if (!clinica.EliminarPaciente(paciente))
            {
                Aviso($"No se puede eliminar a {paciente.Nombre} porque tiene citas registradas.");
                return;
            }

            if (EjecutarEnBaseDeDatos(() => repositorio.EliminarPaciente(paciente)))
                RefrescarPantalla();
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                btnEditarPaciente_Click(sender, e);
        }

        // =================================================================
        //  CITAS
        // =================================================================

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            var paciente = cmbPaciente.SelectedItem as Paciente;
            var medico = cmbMedico.SelectedItem as Medico;
            string motivo = txtMotivo.Text.Trim();

            if (paciente == null || medico == null)
            {
                Aviso("Seleccione un paciente y un médico. Si no hay ninguno, " +
                      "regístrelos con los botones \"+\" o desde el menú Registrar.");
                return;
            }
            if (motivo.Length == 0)
            {
                Aviso("Escriba el motivo de la cita.");
                txtMotivo.Focus();
                return;
            }

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = new TimeSpan(dtpHora.Value.Hour, dtpHora.Value.Minute, 0);

            Cita cita = null;
            bool ok = EjecutarEnBaseDeDatos(() =>
            {
                // La Clínica aplica sus reglas (disponibilidad del médico) y crea la cita;
                // si la creó, la guardamos en la base de datos.
                cita = clinica.AgendarCita(paciente, medico, fecha, hora, motivo);
                if (cita != null)
                    repositorio.GuardarCita(cita);
            });

            if (!ok)
                return;

            if (cita == null)
            {
                Aviso("El médico no tiene agenda disponible en esa fecha y hora.");
                return;
            }

            txtMotivo.Clear();
            RefrescarPantalla();
            SeleccionarFila(dgvCitas, cita);
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            var cita = FilaSeleccionada(dgvCitas) as Cita;
            if (cita == null)
            {
                Aviso("Seleccione una cita de la lista.");
                return;
            }

            string resumen = txtResumen.Text.Trim();
            if (resumen.Length == 0)
            {
                Aviso("Escriba el resumen o diagnóstico de la atención.");
                txtResumen.Focus();
                return;
            }

            // La regla de negocio (solo se atiende una cita PROGRAMADA) la decide la clase Cita.
            if (!cita.AtenderCita(resumen))
            {
                Aviso($"No se puede atender: la cita está {cita.Estado}.");
                return;
            }

            if (EjecutarEnBaseDeDatos(() => repositorio.ActualizarCita(cita)))
            {
                txtResumen.Clear();
                RefrescarPantalla();
                SeleccionarFila(dgvCitas, cita);
            }
        }

        private void btnCancelarCita_Click(object sender, EventArgs e)
        {
            var cita = FilaSeleccionada(dgvCitas) as Cita;
            if (cita == null)
            {
                Aviso("Seleccione una cita de la lista.");
                return;
            }
            if (!Confirmar($"¿Cancelar la cita N° {cita.Id} de {cita.Paciente.Nombre} con {cita.Medico.Nombre}?"))
                return;

            if (!cita.CancelarCita())
            {
                Aviso($"No se puede cancelar: la cita está {cita.Estado}.");
                return;
            }

            if (EjecutarEnBaseDeDatos(() => repositorio.ActualizarCita(cita)))
            {
                RefrescarPantalla();
                SeleccionarFila(dgvCitas, cita);
            }
        }

        // Al cambiar la fila seleccionada mostramos la historia clínica y
        // habilitamos solo los botones que tienen sentido para su estado.
        private void dgvCitas_CurrentCellChanged(object sender, EventArgs e)
        {
            var cita = FilaSeleccionada(dgvCitas) as Cita;
            bool programada = cita != null && cita.Estado == "PROGRAMADA";

            btnAtender.Enabled = programada;
            btnCancelarCita.Enabled = programada;
            txtResumen.Enabled = programada;

            if (cita == null)
                txtHistoria.Text = "";
            else if (cita.Historia != null)
                txtHistoria.Text = cita.Historia.MostrarResumen();
            else
                txtHistoria.Text = "(Esta cita aún no tiene historia clínica: se genera al atenderla.)";
        }

        // Muestra "Nombre (Id)" en los combos de pacientes y médicos.
        private void cmbPersona_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Persona persona)
                e.Value = $"{persona.Nombre} ({persona.Id})";
        }

        // =================================================================
        //  Utilidades
        // =================================================================

        // Vuelve a dibujar las tablas y combos con los datos actuales de la clínica.
        // Cada fila guarda en su propiedad Tag el objeto que representa (Medico, Paciente o Cita).
        private void RefrescarPantalla()
        {
            object pacienteElegido = cmbPaciente.SelectedItem;
            object medicoElegido = cmbMedico.SelectedItem;

            dgvMedicos.Rows.Clear();
            cmbMedico.Items.Clear();
            foreach (Medico m in clinica.Medicos)
            {
                int i = dgvMedicos.Rows.Add(m.Id, m.Nombre, m.Especialidad);
                dgvMedicos.Rows[i].Tag = m;
                cmbMedico.Items.Add(m);
            }

            dgvPacientes.Rows.Clear();
            cmbPaciente.Items.Clear();
            foreach (Paciente p in clinica.Pacientes)
            {
                int i = dgvPacientes.Rows.Add(p.Id, p.Nombre, p.Telefono);
                dgvPacientes.Rows[i].Tag = p;
                cmbPaciente.Items.Add(p);
            }

            // Si el elemento elegido sigue existiendo, lo dejamos seleccionado.
            if (pacienteElegido != null && cmbPaciente.Items.Contains(pacienteElegido))
                cmbPaciente.SelectedItem = pacienteElegido;
            if (medicoElegido != null && cmbMedico.Items.Contains(medicoElegido))
                cmbMedico.SelectedItem = medicoElegido;

            dgvCitas.Rows.Clear();
            foreach (Cita c in clinica.Citas)
            {
                int i = dgvCitas.Rows.Add(
                    c.Id,
                    c.Fecha.ToShortDateString(),
                    c.Hora.ToString(@"hh\:mm"),
                    c.Paciente.Nombre,
                    c.Medico.Nombre,
                    c.Motivo,
                    c.Estado);
                dgvCitas.Rows[i].Tag = c;
            }

            // Los títulos de las pestañas muestran cuántos registros hay.
            tabMedicos.Text = $"Médicos ({clinica.Medicos.Count})";
            tabPacientes.Text = $"Pacientes ({clinica.Pacientes.Count})";
            tabCitas.Text = $"Citas ({clinica.Citas.Count})";

            dgvCitas_CurrentCellChanged(this, EventArgs.Empty);
        }

        private static object FilaSeleccionada(DataGridView tabla)
        {
            return tabla.CurrentRow == null ? null : tabla.CurrentRow.Tag;
        }

        private static void SeleccionarFila(DataGridView tabla, object elemento)
        {
            foreach (DataGridViewRow fila in tabla.Rows)
            {
                if (fila.Tag == elemento)
                {
                    tabla.CurrentCell = fila.Cells[0];
                    return;
                }
            }
        }

        private static bool MismaCedula(Persona persona, string cedula)
        {
            return string.Equals(persona.Id, cedula, StringComparison.OrdinalIgnoreCase);
        }

        // Ejecuta una operación contra la base de datos mostrando los errores de forma amigable.
        // Si algo falla, se recarga la clínica desde la base de datos para que lo que se ve
        // en pantalla coincida con lo realmente guardado.
        private bool EjecutarEnBaseDeDatos(Action accion)
        {
            try
            {
                accion();
                return true;
            }
            catch (Exception ex) when (RepositorioClinica.EsClaveDuplicada(ex))
            {
                Aviso("Ya existe un registro con esa cédula / Id.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo guardar en la base de datos:\n\n" + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RecargarDesdeBaseDeDatos();
            return false;
        }

        private void RecargarDesdeBaseDeDatos()
        {
            try
            {
                clinica = repositorio.CargarClinica();
                RefrescarPantalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Tampoco se pudieron recargar los datos:\n\n" + ex.Message,
                    "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Aviso(string mensaje)
        {
            MessageBox.Show(this, mensaje, "Sistema Clínica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool Confirmar(string pregunta)
        {
            return MessageBox.Show(this, pregunta, "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
