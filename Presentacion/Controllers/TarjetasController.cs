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
    public class TarjetasController : ApiController
    {
        TarjetaBusiness tarjetabusiness = new TarjetaBusiness();
        // GET: api/TARJETAs
        public IQueryable<TARJETA> GetTARJETAs()
        {
            return tarjetabusiness.GetTARJETAs();
        }

        // GET: api/TARJETAs/5
        [ResponseType(typeof(TARJETA))]
        public IHttpActionResult GetTARJETA(int id)
        {
            TARJETA tarjeta = tarjetabusiness.GetTARJETA(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return Ok(tarjeta);
        }

        // PUT: api/TARJETAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTARJETA(int id, TARJETA tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tarjeta.ID_TARJETA)
            {
                return BadRequest();
            }

            try
            {
                tarjetabusiness.PutTARJETA(tarjeta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TARJETAExists(id))
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

        // POST: api/TARJETAs
        [ResponseType(typeof(TARJETA))]
        public IHttpActionResult PostTARJETA(TARJETA tarjeta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tarjetabusiness.PostTARJETA(tarjeta);

            return CreatedAtRoute("DefaultApi", new { id = tarjeta.ID_TARJETA }, tarjeta);
        }

        // DELETE: api/TARJETAs/5
        [ResponseType(typeof(TARJETA))]
        public IHttpActionResult DeleteTARJETA(int id)
        {
            TARJETA tarjeta = tarjetabusiness.GetTARJETA(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            tarjetabusiness.DeleteTARJETA(id);
            return Ok(tarjeta);
        }

        [Route("api/Tarjetas/PorCliente/{id}")]
        [HttpGet]
        public IHttpActionResult GetTARJETAs_Cliente(int id)
        {
            IQueryable<TARJETA> tarjeta = tarjetabusiness.GetTARJETAs_Cliente(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            return Ok(tarjeta);
        }
        private bool TARJETAExists(int id)
        {
            return tarjetabusiness.TARJETAexists(id);
        }
    }
}