using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace SistemaClinica
{
    // CAPA DE ACCESO A DATOS (patrón Repositorio):
    // Traduce entre los objetos del modelo (Medico, Paciente, Cita, HistoriaClinica)
    // y las tablas de la base de datos SQLite. Así las clases del UML no necesitan saber nada de SQL.
    //
    // SQLite guarda toda la base de datos en un único archivo (clinica.db) junto al programa,
    // por lo que no hay que instalar ningún servidor de base de datos.
    public class RepositorioClinica
    {
        private const string NombreCadenaConexion = "SistemaClinica";
        private const string RecursoEsquema = "SistemaClinica.BaseDeDatos.Esquema.sql";

        // Formatos con los que se guardan fechas y horas como texto (ISO, independiente del idioma de Windows).
        private const string FormatoFecha = "yyyy-MM-dd";
        private const string FormatoHora = @"hh\:mm\:ss";
        private const string FormatoFechaHora = "yyyy-MM-dd HH:mm:ss";

        private readonly string cadenaConexion;

        // Lee la cadena de conexión desde App.config (<connectionStrings>).
        public RepositorioClinica()
        {
            ConnectionStringSettings config = ConfigurationManager.ConnectionStrings[NombreCadenaConexion];
            if (config == null)
                throw new ConfigurationErrorsException(
                    $"No se encontró la cadena de conexión '{NombreCadenaConexion}' en App.config.");
            this.cadenaConexion = config.ConnectionString;
        }

        public RepositorioClinica(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        // ---------------------------------------------------------------
        //  Creación de la base de datos y las tablas
        // ---------------------------------------------------------------

        // Si el archivo de la base de datos no existe, SQLite lo crea al abrir la conexión.
        // Después se ejecuta el script de tablas (incrustado en el .exe como recurso).
        public void InicializarBaseDeDatos()
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(LeerScriptEsquema(), conexion))
            {
                comando.ExecuteNonQuery();
            }
        }

        private static string LeerScriptEsquema()
        {
            using (Stream recurso = Assembly.GetExecutingAssembly().GetManifestResourceStream(RecursoEsquema))
            {
                if (recurso == null)
                    throw new InvalidOperationException($"No se encontró el recurso incrustado '{RecursoEsquema}'.");
                using (var lector = new StreamReader(recurso))
                    return lector.ReadToEnd();
            }
        }

        private SQLiteConnection AbrirConexion()
        {
            var conexion = new SQLiteConnection(cadenaConexion);
            conexion.Open();

            // SQLite no revisa las claves foráneas a menos que se active en cada conexión.
            using (var comando = new SQLiteCommand("PRAGMA foreign_keys = ON;", conexion))
                comando.ExecuteNonQuery();

            return conexion;
        }

        // ---------------------------------------------------------------
        //  Lectura: reconstruye la Clínica completa desde la base de datos
        // ---------------------------------------------------------------

        public Clinica CargarClinica()
        {
            var clinica = new Clinica();
            // Diccionarios para encontrar rápido el médico/paciente de cada cita por su Id.
            var medicos = new Dictionary<string, Medico>(StringComparer.OrdinalIgnoreCase);
            var pacientes = new Dictionary<string, Paciente>(StringComparer.OrdinalIgnoreCase);

            using (SQLiteConnection conexion = AbrirConexion())
            {
                using (var comando = new SQLiteCommand(
                    "SELECT Id, Nombre, Especialidad FROM Medicos ORDER BY Nombre", conexion))
                using (SQLiteDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var medico = new Medico(lector.GetString(0), lector.GetString(1), LeerTextoOpcional(lector, 2));
                        medicos.Add(medico.Id, medico);
                        clinica.RegistrarMedico(medico);
                    }
                }

                using (var comando = new SQLiteCommand(
                    "SELECT Id, Nombre, Telefono FROM Pacientes ORDER BY Nombre", conexion))
                using (SQLiteDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        var paciente = new Paciente(lector.GetString(0), lector.GetString(1), LeerTextoOpcional(lector, 2));
                        pacientes.Add(paciente.Id, paciente);
                        clinica.RegistrarPaciente(paciente);
                    }
                }

                // LEFT JOIN: trae también las citas que todavía no tienen historia clínica.
                using (var comando = new SQLiteCommand(
                    "SELECT c.Id, c.Fecha, c.Hora, c.Motivo, c.Estado, c.MedicoId, c.PacienteId, " +
                    "       h.FechaGeneracion, h.Resumen " +
                    "FROM Citas c LEFT JOIN HistoriasClinicas h ON h.CitaId = c.Id " +
                    "ORDER BY c.Fecha, c.Hora", conexion))
                using (SQLiteDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        HistoriaClinica historia = null;
                        if (!lector.IsDBNull(7))
                        {
                            historia = new HistoriaClinica(
                                DateTime.ParseExact(lector.GetString(7), FormatoFechaHora, CultureInfo.InvariantCulture),
                                lector.GetString(8));
                        }

                        var cita = new Cita(
                            Convert.ToInt32(lector.GetInt64(0)),
                            DateTime.ParseExact(lector.GetString(1), FormatoFecha, CultureInfo.InvariantCulture),
                            TimeSpan.ParseExact(lector.GetString(2), FormatoHora, CultureInfo.InvariantCulture),
                            LeerTextoOpcional(lector, 3),
                            lector.GetString(4),
                            medicos[lector.GetString(5)],
                            pacientes[lector.GetString(6)],
                            historia);
                        clinica.CargarCita(cita);
                    }
                }
            }

            return clinica;
        }

        private static string LeerTextoOpcional(SQLiteDataReader lector, int columna)
        {
            return lector.IsDBNull(columna) ? null : lector.GetString(columna);
        }

        // ---------------------------------------------------------------
        //  Escritura
        // ---------------------------------------------------------------

        public void GuardarMedico(Medico medico)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(
                "INSERT INTO Medicos (Id, Nombre, Especialidad) VALUES (@id, @nombre, @especialidad)", conexion))
            {
                comando.Parameters.AddWithValue("@id", medico.Id);
                comando.Parameters.AddWithValue("@nombre", medico.Nombre);
                comando.Parameters.AddWithValue("@especialidad", ValorONulo(medico.Especialidad));
                comando.ExecuteNonQuery();
            }
        }

        public void GuardarPaciente(Paciente paciente)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(
                "INSERT INTO Pacientes (Id, Nombre, Telefono) VALUES (@id, @nombre, @telefono)", conexion))
            {
                comando.Parameters.AddWithValue("@id", paciente.Id);
                comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                comando.Parameters.AddWithValue("@telefono", ValorONulo(paciente.Telefono));
                comando.ExecuteNonQuery();
            }
        }

        // La cédula (Id) no se modifica: es la clave primaria. Solo cambian los demás datos.
        public void ActualizarMedico(Medico medico)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(
                "UPDATE Medicos SET Nombre = @nombre, Especialidad = @especialidad WHERE Id = @id", conexion))
            {
                comando.Parameters.AddWithValue("@id", medico.Id);
                comando.Parameters.AddWithValue("@nombre", medico.Nombre);
                comando.Parameters.AddWithValue("@especialidad", ValorONulo(medico.Especialidad));
                if (comando.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException($"No existe el médico con cédula {medico.Id} en la base de datos.");
            }
        }

        public void ActualizarPaciente(Paciente paciente)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(
                "UPDATE Pacientes SET Nombre = @nombre, Telefono = @telefono WHERE Id = @id", conexion))
            {
                comando.Parameters.AddWithValue("@id", paciente.Id);
                comando.Parameters.AddWithValue("@nombre", paciente.Nombre);
                comando.Parameters.AddWithValue("@telefono", ValorONulo(paciente.Telefono));
                if (comando.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException($"No existe el paciente con cédula {paciente.Id} en la base de datos.");
            }
        }

        // La clave foránea de Citas impide borrar un médico/paciente que tenga citas
        // (la Clínica ya lo verifica antes, esto es una segunda protección).
        public void EliminarMedico(Medico medico)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand("DELETE FROM Medicos WHERE Id = @id", conexion))
            {
                comando.Parameters.AddWithValue("@id", medico.Id);
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarPaciente(Paciente paciente)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand("DELETE FROM Pacientes WHERE Id = @id", conexion))
            {
                comando.Parameters.AddWithValue("@id", paciente.Id);
                comando.ExecuteNonQuery();
            }
        }

        // Inserta una cita nueva y le asigna el Id generado por la base de datos.
        public void GuardarCita(Cita cita)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (var comando = new SQLiteCommand(
                "INSERT INTO Citas (Fecha, Hora, Motivo, Estado, MedicoId, PacienteId) " +
                "VALUES (@fecha, @hora, @motivo, @estado, @medicoId, @pacienteId)", conexion))
            {
                comando.Parameters.AddWithValue("@fecha", cita.Fecha.ToString(FormatoFecha, CultureInfo.InvariantCulture));
                comando.Parameters.AddWithValue("@hora", cita.Hora.ToString(FormatoHora, CultureInfo.InvariantCulture));
                comando.Parameters.AddWithValue("@motivo", ValorONulo(cita.Motivo));
                comando.Parameters.AddWithValue("@estado", cita.Estado);
                comando.Parameters.AddWithValue("@medicoId", cita.Medico.Id);
                comando.Parameters.AddWithValue("@pacienteId", cita.Paciente.Id);
                comando.ExecuteNonQuery();

                // Id autoincremental que SQLite le asignó a la fila recién insertada.
                cita.Id = Convert.ToInt32(conexion.LastInsertRowId);
            }
        }

        // Guarda el nuevo estado de una cita y, si ya fue atendida, su historia clínica.
        // Se usa una TRANSACCIÓN para que ambas cosas se guarden juntas o ninguna.
        public void ActualizarCita(Cita cita)
        {
            using (SQLiteConnection conexion = AbrirConexion())
            using (SQLiteTransaction transaccion = conexion.BeginTransaction())
            {
                using (var comando = new SQLiteCommand(
                    "UPDATE Citas SET Estado = @estado WHERE Id = @id", conexion, transaccion))
                {
                    comando.Parameters.AddWithValue("@estado", cita.Estado);
                    comando.Parameters.AddWithValue("@id", cita.Id);
                    if (comando.ExecuteNonQuery() != 1)
                        throw new InvalidOperationException($"No existe la cita con Id {cita.Id} en la base de datos.");
                }

                if (cita.Historia != null)
                {
                    // INSERT OR IGNORE: si la cita ya tenía historia, no se sobrescribe.
                    using (var comando = new SQLiteCommand(
                        "INSERT OR IGNORE INTO HistoriasClinicas (CitaId, FechaGeneracion, Resumen) " +
                        "VALUES (@citaId, @fecha, @resumen)", conexion, transaccion))
                    {
                        comando.Parameters.AddWithValue("@citaId", cita.Id);
                        comando.Parameters.AddWithValue("@fecha",
                            cita.Historia.FechaGeneracion.ToString(FormatoFechaHora, CultureInfo.InvariantCulture));
                        comando.Parameters.AddWithValue("@resumen", cita.Historia.Resumen);
                        comando.ExecuteNonQuery();
                    }
                }

                transaccion.Commit();
            }
        }

        private static object ValorONulo(string valor)
        {
            return string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor;
        }

        // Indica si el error se debe a una clave primaria repetida
        // (por ejemplo, registrar dos veces un médico con la misma cédula).
        public static bool EsClaveDuplicada(Exception ex)
        {
            var errorSqlite = ex as SQLiteException;
            return errorSqlite != null
                && errorSqlite.ResultCode == SQLiteErrorCode.Constraint
                && errorSqlite.Message.IndexOf("UNIQUE", StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
