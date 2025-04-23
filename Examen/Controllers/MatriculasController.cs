using Examen.Clases;
using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examen.Controllers
{
    [RoutePrefix("api/Matriculas")]
    [Authorize]
    public class MatriculasController : ApiController
    {
        [HttpGet]
        [Route("Consultar")]
        public IHttpActionResult Consultar(string documento, string semestre)
        {
            try
            {
                if (string.IsNullOrEmpty(documento) || string.IsNullOrEmpty(semestre))
                {
                    return BadRequest("Documento y semestre son requeridos");
                }
                clsMatricula matricula = new clsMatricula();
                var mat = matricula.Consultar(documento, semestre);
                if (mat == null)
                {
                    return NotFound(); 
                }

                return Ok(matricula); 
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); 
            }
        }
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Matricula matricula)
        {
            Examen.Clases.clsMatricula clsMatricula = new Examen.Clases.clsMatricula();
            clsMatricula.matricula = matricula;
            return clsMatricula.Insertar();
        }
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Matricula matricula)
        {
            Examen.Clases.clsMatricula clsMatricula = new Examen.Clases.clsMatricula();
            clsMatricula.matricula = matricula;
            return clsMatricula.Actualizar();
        }
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Matricula matricula)
        {
            Examen.Clases.clsMatricula clsMatricula = new Examen.Clases.clsMatricula();
            clsMatricula.matricula = matricula;
            return clsMatricula.Eliminar();
        }
    }
}
