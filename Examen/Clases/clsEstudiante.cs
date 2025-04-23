using Examen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen.Clases
{
    public class clsEstudiante
    {
        private DBExamenEntities dbExamen = new DBExamenEntities();
        public Estudiante estudiante { get; set; }

        public string Insertar()
        {
            try
            {
                dbExamen.Estudiantes.Add(estudiante);
                dbExamen.SaveChanges();
                return "Estudiante registrado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al registrar el estudiante: " + ex.Message;
            }
        }

        public string Actualizar()
        {
            Estudiante est = Consultar(estudiante.Documento);
            if (est == null)
            {
                return "El documento del estudiante no es válido";
            }
            dbExamen.Estudiantes.AddOrUpdate(estudiante);
            dbExamen.SaveChanges();
            return "Estudiante actualizado correctamente";
        }

        public Estudiante Consultar(string Documento)
        {
            Estudiante est = dbExamen.Estudiantes.FirstOrDefault(e => e.Documento == Documento);
            return est;
        }
        public string Eliminar()
        {
            Estudiante est = Consultar(estudiante.Documento);
            if (est == null)
            {
                return "El documento del estudiante no es válido";
            }
            dbExamen.Estudiantes.Remove(est);
            dbExamen.SaveChanges();
            return "Estudiante eliminado correctamente";
        }
        public List<Estudiante> ConsultarTodos()
        {
            return dbExamen.Estudiantes.ToList();
        }
    }
}
