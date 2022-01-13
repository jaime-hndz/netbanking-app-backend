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
    public class ClientesController : ApiController
    {
        ClienteBusiness clientebusiness = new ClienteBusiness();
        // GET: api/CLIENTEs
        public IQueryable<CLIENTE> GetCLIENTEs()
        {
            return clientebusiness.GetCLIENTEs();
        }

        // GET: api/CLIENTEs/5
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult GetCLIENTE(int id)
        {
            CLIENTE cliente = clientebusiness.GetCLIENTE(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/CLIENTEs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLIENTE(int id, CLIENTE cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.ID_CLIENTE)
            {
                return BadRequest();
            }

            try
            {
                clientebusiness.PutCLIENTE(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTEExists(id))
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

        // POST: api/CLIENTEs
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult PostCLIENTE(CLIENTE cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            clientebusiness.PostCLIENTE(cliente);

            return CreatedAtRoute("DefaultApi", new { id = cliente.ID_CLIENTE }, cliente);
        }

        // DELETE: api/CLIENTEs/5
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult DeleteCLIENTE(int id)
        {
            CLIENTE cliente = clientebusiness.GetCLIENTE(id);
            if (cliente == null)
            {
                return NotFound();
            }

            clientebusiness.DeleteCLIENTE(id);
            return Ok(cliente);
        }


        private bool CLIENTEExists(int id)
        {
            return clientebusiness.CLIENTEexists(id);
        }
    }
}