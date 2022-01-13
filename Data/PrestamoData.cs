using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PrestamoData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/PRESTAMOs
        public IQueryable<PRESTAMO> GetPRESTAMOs()
        {
            return db.PRESTAMOs;
        }

        // GET: api/PRESTAMOs/5
        public PRESTAMO GetPRESTAMO(int id)
        {
            PRESTAMO prestamo = db.PRESTAMOs.Find(id);
            if (prestamo == null)
            {
                return null;
            }

            return prestamo;
        }

        // PUT: api/PRESTAMOs/5
        public void PutPRESTAMO(PRESTAMO prestamo)
        {

            db.Entry(prestamo).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/PRESTAMOs
        public void PostPRESTAMO(PRESTAMO prestamo)
        {

            db.PRESTAMOs.Add(prestamo);
            db.SaveChanges();

        }

        // DELETE: api/PRESTAMOs/5
        public void DeletePRESTAMO(int id)
        {
            PRESTAMO prestamo = db.PRESTAMOs.Find(id);
            db.PRESTAMOs.Remove(prestamo);
            db.SaveChanges();
        }

        public bool PRESTAMOexists(int id)
        {
            return db.PRESTAMOs.Count(e => e.ID_PRESTAMO == id) > 0;
        }

        public IQueryable<PRESTAMO> GetPRESTAMOs_Cliente(int id)
        {
            return db.PRESTAMOs.Where(x => x.ID_CLIENTE == id);
        }
    }
}
