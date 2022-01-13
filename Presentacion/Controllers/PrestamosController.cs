using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Entity;
using Business;

namespace Presentacion.Controllers
{
    public class PrestamosController : ApiController
    {
        PrestamoBusiness prestamobusiness = new PrestamoBusiness();
        // GET: api/PRESTAMOs
        public IQueryable<PRESTAMO> GetPRESTAMOs()
        {
            return prestamobusiness.GetPRESTAMOs();
        }

        // GET: api/PRESTAMOs/5
        [ResponseType(typeof(PRESTAMO))]
        public IHttpActionResult GetPRESTAMO(int id)
        {
            PRESTAMO prestamo = prestamobusiness.GetPRESTAMO(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }

        // PUT: api/PRESTAMOs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRESTAMO(int id, PRESTAMO prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.ID_PRESTAMO)
            {
                return BadRequest();
            }

            try
            {
                prestamobusiness.PutPRESTAMO(prestamo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRESTAMOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        [Route("api/Prestamo/Cuota/{id}/{prestamo}/{val}")]
        [HttpPut]
        public IHttpActionResult PutPRESTAMOCUOTA(int id, PRESTAMO prestamo, float val)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prestamo.ID_PRESTAMO)
            {
                return BadRequest();
            }

            try
            {
                prestamobusiness.PutPRESTAMOCUOTA(prestamo, val);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRESTAMOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PRESTAMOs
        [ResponseType(typeof(PRESTAMO))]
        public IHttpActionResult PostPRESTAMO(PRESTAMO prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            prestamobusiness.PostPRESTAMO(prestamo);

            return CreatedAtRoute("DefaultApi", new { id = prestamo.ID_PRESTAMO }, prestamo);
        }

        // DELETE: api/PRESTAMOs/5
        [ResponseType(typeof(PRESTAMO))]
        public IHttpActionResult DeletePRESTAMO(int id)
        {
            PRESTAMO prestamo = prestamobusiness.GetPRESTAMO(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            prestamobusiness.DeletePRESTAMO(id);
            return Ok(prestamo);
        }

        [Route("api/Prestamos/PorCliente/{id}")]
        [HttpGet]
        public IHttpActionResult GetPRESTAMOs_Cliente(int id)
        {
            IQueryable<PRESTAMO> prestamo = prestamobusiness.GetPRESTAMOs_Cliente(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            return Ok(prestamo);
        }
        private bool PRESTAMOExists(int id)
        {
            return prestamobusiness.PRESTAMOexists(id);
        }
    }
}