using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CuentaData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/CUENTAs
        public IQueryable<CUENTA> GetCUENTAs()
        {
            return db.CUENTAs;
        }

        // GET: api/CUENTAs/5
        public CUENTA GetCUENTA(int id)
        {
            CUENTA cuenta = db.CUENTAs.Find(id);
            if (cuenta == null)
            {
                return null;
            }

            return cuenta;
        }

        // PUT: api/CUENTAs/5
        public void PutCUENTA(CUENTA cuenta)
        {

            db.Entry(cuenta).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/CUENTAs
        public void PostCUENTA(CUENTA cuenta)
        {

            db.CUENTAs.Add(cuenta);
            db.SaveChanges();

        }

        // DELETE: api/CUENTAs/5
        public void DeleteCUENTA(int id)
        {
            CUENTA cuenta = db.CUENTAs.Find(id);
            db.CUENTAs.Remove(cuenta);
            db.SaveChanges();
        }

        public bool CUENTAexists(int id)
        {
            return db.CUENTAs.Count(e => e.ID_CUENTA == id) > 0;
        }

        public IQueryable<CUENTA> GetCUENTAs_Cliente(int id)
        {
            return db.CUENTAs.Where(x => x.ID_CLIENTE == id);
        }

    }
}
