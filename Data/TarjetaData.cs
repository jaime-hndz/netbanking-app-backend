using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TarjetaData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/TARJETAs
        public IQueryable<TARJETA> GetTARJETAs()
        {
            return db.TARJETAs;
        }

        // GET: api/TARJETAs/5
        public TARJETA GetTARJETA(int id)
        {
            TARJETA cuenta = db.TARJETAs.Find(id);
            if (cuenta == null)
            {
                return null;
            }

            return cuenta;
        }

        // PUT: api/TARJETAs/5
        public void PutTARJETA(TARJETA cuenta)
        {

            db.Entry(cuenta).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/TARJETAs
        public void PostTARJETA(TARJETA cuenta)
        {

            db.TARJETAs.Add(cuenta);
            db.SaveChanges();

        }

        // DELETE: api/TARJETAs/5
        public void DeleteTARJETA(int id)
        {
            TARJETA cuenta = db.TARJETAs.Find(id);
            db.TARJETAs.Remove(cuenta);
            db.SaveChanges();
        }

        public bool TARJETAexists(int id)
        {
            return db.TARJETAs.Count(e => e.ID_TARJETA == id) > 0;
        }

        public IQueryable<TARJETA> GetTARJETAs_Cliente(int id)
        {
            return db.TARJETAs.Where(x => x.ID_CLIENTE == id);
        }

    }
}
