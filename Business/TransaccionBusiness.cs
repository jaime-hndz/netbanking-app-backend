using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TransaccionBusiness
    {
        TransaccionData transacciondata = new TransaccionData();
        public IQueryable<TRANSACCION> GetTRANSACCIONs()
        {
            return transacciondata.GetTRANSACCIONs();
        }

        // GET: api/TRANSACCIONs/5
        public TRANSACCION GetTRANSACCION(int id)
        {
            TRANSACCION transaccion = transacciondata.GetTRANSACCION(id);
            return transaccion;
        }

        // PUT: api/TRANSACCIONs/5
        public void PutTRANSACCION(TRANSACCION transaccion)
        {

            transacciondata.PutTRANSACCION(transaccion);

        }

        // POST: api/TRANSACCIONs
        public void PostTRANSACCION(TRANSACCION transaccion)
        {

            transacciondata.PostTRANSACCION(transaccion);

        }

        // DELETE: api/TRANSACCIONs/5
        public void DeleteTRANSACCION(int id)
        {
            transacciondata.DeleteTRANSACCION(id);
        }

        public bool TRANSACCIONexists(int id)
        {
            return transacciondata.TRANSACCIONexists(id);
        }
    }
}
