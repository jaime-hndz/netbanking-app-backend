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
    public class CuotasController : ApiController
    {
        CuotaBusiness cuotabusiness = new CuotaBusiness();
        // GET: api/CUOTAs
        public IQueryable<CUOTA> GetCUOTAs()
        {
            return cuotabusiness.GetCUOTAs();
        }

        // GET: api/CUOTAs/5
        [ResponseType(typeof(CUOTA))]
        public IHttpActionResult GetCUOTA(int id)
        {
            CUOTA cuota = cuotabusiness.GetCUOTA(id);
            if (cuota == null)
            {
                return NotFound();
            }

            return Ok(cuota);
        }

        // PUT: api/CUOTAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCUOTA(int id, CUOTA cuota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuota.ID_CUOTA)
            {
                return BadRequest();
            }

            try
            {
                cuotabusiness.PutCUOTA(cuota);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUOTAExists(id))
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

        // POST: api/CUOTAs
        [ResponseType(typeof(CUOTA))]
        public IHttpActionResult PostCUOTA(CUOTA cuota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cuotabusiness.PostCUOTA(cuota);

            return CreatedAtRoute("DefaultApi", new { id = cuota.ID_CUOTA }, cuota);
        }

        // DELETE: api/CUOTAs/5
        [ResponseType(typeof(CUOTA))]
        public IHttpActionResult DeleteCUOTA(int id)
        {
            CUOTA cuota = cuotabusiness.GetCUOTA(id);
            if (cuota == null)
            {
                return NotFound();
            }

            cuotabusiness.DeleteCUOTA(id);
            return Ok(cuota);
        }


        private bool CUOTAExists(int id)
        {
            return cuotabusiness.CUOTAexists(id);
        }
    }
}