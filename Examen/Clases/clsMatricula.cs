using Examen.Models;
using System;
using System.Linq;

namespace Examen.Clases
{
    public class clsMatricula
    {
        private DBExamenEntities dbExamen = new DBExamenEntities();
        public Estudiante estudiante { get; set; }
        public Matricula matricula { get; set; }

        public string Insertar()
        {
            try
            {
                matricula.TotalMatricula = matricula.NumeroCreditos * matricula.ValorCredito;
                dbExamen.Matriculas.Add(matricula);
                dbExamen.SaveChanges();
                return "Matrícula registrada correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar la matrícula: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Matricula mat = dbExamen.Matriculas.FirstOrDefault(m => m.idMatricula == matricula.idMatricula);
            if (mat == null)
            {
                return "El id de la matrícula no es válido";
            }

            mat.NumeroCreditos = matricula.NumeroCreditos;
            mat.ValorCredito = matricula.ValorCredito;
            mat.TotalMatricula = matricula.NumeroCreditos * matricula.ValorCredito;
            mat.FechaMatricula = matricula.FechaMatricula;
            mat.SemestreMatricula = matricula.SemestreMatricula;
            mat.MateriasMatriculadas = matricula.MateriasMatriculadas;

            dbExamen.SaveChanges();
            return "Matrícula actualizada correctamente";
        }

        public Matricula Consultar(string documento, string semestre)
        {
            try
            {
                // Buscar al estudiante por documento
                estudiante = dbExamen.Estudiantes.FirstOrDefault(e => e.Documento == documento);

                if (estudiante == null)
                {
                    throw new Exception("Estudiante no encontrado con el documento proporcionado.");
                }

                // Buscar matrícula por idEstudiante y semestre
                var matricula = dbExamen.Matriculas
                    .FirstOrDefault(m => m.idEstudiante == estudiante.idEstudiante && m.SemestreMatricula == semestre);

                if (matricula == null)
                {
                    throw new Exception("No se encontró matrícula para el semestre especificado.");
                }

                return matricula;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar matrícula: " + ex.Message);
            }
        }

        public string Eliminar()
        {
            Matricula mat = dbExamen.Matriculas.FirstOrDefault(m => m.idMatricula == matricula.idMatricula);
            if (mat == null)
            {
                return "El id de la matrícula no es válido";
            }

            dbExamen.Matriculas.Remove(mat);
            dbExamen.SaveChanges();
            return "Matrícula eliminada correctamente";
        }
    }
}
