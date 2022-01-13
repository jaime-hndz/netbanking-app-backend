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
    public class TransaccionesController : ApiController
    {
        TransaccionBusiness transaccionbusiness = new TransaccionBusiness();
        // GET: api/TRANSACCIONs
        public IQueryable<TRANSACCION> GetTRANSACCIONs()
        {
            return transaccionbusiness.GetTRANSACCIONs();
        }

        // GET: api/TRANSACCIONs/5
        [ResponseType(typeof(TRANSACCION))]
        public IHttpActionResult GetTRANSACCION(int id)
        {
            TRANSACCION transaccion = transaccionbusiness.GetTRANSACCION(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            return Ok(transaccion);
        }

        // PUT: api/TRANSACCIONs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTRANSACCION(int id, TRANSACCION transaccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaccion.ID_TRANSACCION)
            {
                return BadRequest();
            }

            try
            {
                transaccionbusiness.PutTRANSACCION(transaccion);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TRANSACCIONExists(id))
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

        // POST: api/TRANSACCIONs
        [ResponseType(typeof(TRANSACCION))]
        public IHttpActionResult PostTRANSACCION(TRANSACCION transaccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            transaccionbusiness.PostTRANSACCION(transaccion);

            return CreatedAtRoute("DefaultApi", new { id = transaccion.ID_TRANSACCION }, transaccion);
        }

        // DELETE: api/TRANSACCIONs/5
        [ResponseType(typeof(TRANSACCION))]
        public IHttpActionResult DeleteTRANSACCION(int id)
        {
            TRANSACCION transaccion = transaccionbusiness.GetTRANSACCION(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            transaccionbusiness.DeleteTRANSACCION(id);
            return Ok(transaccion);
        }


        private bool TRANSACCIONExists(int id)
        {
            return transaccionbusiness.TRANSACCIONexists(id);
        }
    }
}