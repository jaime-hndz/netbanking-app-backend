using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClienteData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/CLIENTEs
        public IQueryable<CLIENTE> GetCLIENTEs()
        {
            return db.CLIENTEs;
        }

        // GET: api/CLIENTEs/5
        public CLIENTE GetCLIENTE(int id)
        {
            CLIENTE cliente = db.CLIENTEs.Find(id);
            if (cliente == null)
            {
                return null;
            }

            return cliente;
        }

        // PUT: api/CLIENTEs/5
        public void PutCLIENTE(CLIENTE cliente)
        {

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/CLIENTEs
        public void PostCLIENTE(CLIENTE cliente)
        {

            db.CLIENTEs.Add(cliente);
            db.SaveChanges();

        }

        // DELETE: api/CLIENTEs/5
        public void DeleteCLIENTE(int id)
        {
            CLIENTE cliente = db.CLIENTEs.Find(id);
            db.CLIENTEs.Remove(cliente);
            db.SaveChanges();
        }

        public bool CLIENTEexists(int id)
        {
            return db.CLIENTEs.Count(e => e.ID_CLIENTE == id) > 0;
        }

    }
}
