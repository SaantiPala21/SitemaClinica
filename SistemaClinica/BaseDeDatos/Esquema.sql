-- =====================================================================
--  Esquema de la base de datos de SistemaClinica (SQLite).
--  El programa ejecuta este script automáticamente al iniciar
--  (va incrustado en el .exe). "IF NOT EXISTS" hace que solo cree
--  lo que falte, así que se puede ejecutar todas las veces que sea.
--
--  Fechas y horas se guardan como texto en formato ISO:
--    Fecha 'yyyy-MM-dd', Hora 'HH:mm:ss', FechaGeneracion 'yyyy-MM-dd HH:mm:ss'.
-- =====================================================================

-- COLLATE NOCASE: la cédula "ABC1" y "abc1" se consideran la misma.
CREATE TABLE IF NOT EXISTS Medicos (
    Id           TEXT NOT NULL COLLATE NOCASE PRIMARY KEY,
    Nombre       TEXT NOT NULL,
    Especialidad TEXT NULL
);

CREATE TABLE IF NOT EXISTS Pacientes (
    Id       TEXT NOT NULL COLLATE NOCASE PRIMARY KEY,
    Nombre   TEXT NOT NULL,
    Telefono TEXT NULL
);

-- Asociación: cada cita referencia a un médico y a un paciente.
CREATE TABLE IF NOT EXISTS Citas (
    Id         INTEGER PRIMARY KEY AUTOINCREMENT,
    Fecha      TEXT NOT NULL,
    Hora       TEXT NOT NULL,
    Motivo     TEXT NULL,
    Estado     TEXT NOT NULL CHECK (Estado IN ('PROGRAMADA', 'CANCELADA', 'ATENDIDA')),
    MedicoId   TEXT NOT NULL REFERENCES Medicos(Id),
    PacienteId TEXT NOT NULL REFERENCES Pacientes(Id)
);

-- Composición (0..1): la historia clínica pertenece a una única cita.
-- La clave primaria es el mismo Id de la cita (como máximo una historia por cita)
-- y ON DELETE CASCADE hace que la historia "muera" junto con su cita.
CREATE TABLE IF NOT EXISTS HistoriasClinicas (
    CitaId          INTEGER NOT NULL PRIMARY KEY REFERENCES Citas(Id) ON DELETE CASCADE,
    FechaGeneracion TEXT    NOT NULL,
    Resumen         TEXT    NOT NULL
);
