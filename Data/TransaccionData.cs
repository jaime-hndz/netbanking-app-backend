using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TransaccionData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/TRANSACCIONs
        public IQueryable<TRANSACCION> GetTRANSACCIONs()
        {
            return db.TRANSACCIONs;
        }

        // GET: api/TRANSACCIONs/5
        public TRANSACCION GetTRANSACCION(int id)
        {
            TRANSACCION transaccion = db.TRANSACCIONs.Find(id);
            if (transaccion == null)
            {
                return null;
            }

            return transaccion;
        }

        // PUT: api/TRANSACCIONs/5
        public void PutTRANSACCION(TRANSACCION transaccion)
        {

            db.Entry(transaccion).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/TRANSACCIONs
        public void PostTRANSACCION(TRANSACCION transaccion)
        {

            db.TRANSACCIONs.Add(transaccion);
            db.SaveChanges();

        }

        // DELETE: api/TRANSACCIONs/5
        public void DeleteTRANSACCION(int id)
        {
            TRANSACCION transaccion = db.TRANSACCIONs.Find(id);
            db.TRANSACCIONs.Remove(transaccion);
            db.SaveChanges();
        }

        public bool TRANSACCIONexists(int id)
        {
            return db.TRANSACCIONs.Count(e => e.ID_TRANSACCION == id) > 0;
        }
    }
}
