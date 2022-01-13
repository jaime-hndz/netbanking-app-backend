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
    public class CuentasController : ApiController
    {
        CuentaBusiness cuentabusiness = new CuentaBusiness();
        // GET: api/CUENTAs
        public IQueryable<CUENTA> GetCUENTAs()
        {
            return cuentabusiness.GetCUENTAs();
        }

        // GET: api/CUENTAs/5
        [ResponseType(typeof(CUENTA))]
        public IHttpActionResult GetCUENTA(int id)
        {
            CUENTA cuenta = cuentabusiness.GetCUENTA(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        // PUT: api/CUENTAs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCUENTA(int id, CUENTA cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.ID_CUENTA)
            {
                return BadRequest();
            }

            try
            {
                cuentabusiness.PutCUENTA(cuenta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUENTAExists(id))
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

        // POST: api/CUENTAs
        [ResponseType(typeof(CUENTA))]
        public IHttpActionResult PostCUENTA(CUENTA cuenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cuentabusiness.PostCUENTA(cuenta);

            return CreatedAtRoute("DefaultApi", new { id = cuenta.ID_CUENTA }, cuenta);
        }

        // DELETE: api/CUENTAs/5
        [ResponseType(typeof(CUENTA))]
        public IHttpActionResult DeleteCUENTA(int id)
        {
            CUENTA cuenta = cuentabusiness.GetCUENTA(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            cuentabusiness.DeleteCUENTA(id);
            return Ok(cuenta);
        }

        [Route("api/Cuentas/PorCliente/{id}")]
        [HttpGet]
        public IHttpActionResult GetCUENTAs_Cliente(int id)
        {
            IQueryable<CUENTA> cuenta = cuentabusiness.GetCUENTAs_Cliente(id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return Ok(cuenta);
        }

        [Route("api/Cuentas/Transaccion/{id}/{val}/{newval}")]
        [HttpPut]
        public IHttpActionResult PutCUENTAs_TRANSACCION(int id, CUENTA cuenta, float val, float newval)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuenta.ID_CUENTA)
            {
                return BadRequest();
            }

            try
            {
                cuentabusiness.PutCUENTATRANSACCION(cuenta, val,newval);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CUENTAExists(id))
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

        private bool CUENTAExists(int id)
        {
            return cuentabusiness.CUENTAexists(id);
        }
    }
}