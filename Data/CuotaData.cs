using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CuotaData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/CUOTAs
        public IQueryable<CUOTA> GetCUOTAs()
        {
            return db.CUOTAs;
        }

        // GET: api/CUOTAs/5
        public CUOTA GetCUOTA(int id)
        {
            CUOTA cuota = db.CUOTAs.Find(id);
            if (cuota == null)
            {
                return null;
            }

            return cuota;
        }

        // PUT: api/CUOTAs/5
        public void PutCUOTA(CUOTA cuota)
        {

            db.Entry(cuota).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/CUOTAs
        public void PostCUOTA(CUOTA cuota)
        {

            db.CUOTAs.Add(cuota);
            db.SaveChanges();

        }

        // DELETE: api/CUOTAs/5
        public void DeleteCUOTA(int id)
        {
            CUOTA cuota = db.CUOTAs.Find(id);
            db.CUOTAs.Remove(cuota);
            db.SaveChanges();
        }

        public bool CUOTAexists(int id)
        {
            return db.CUOTAs.Count(e => e.ID_CUOTA == id) > 0;
        }
    }
}
