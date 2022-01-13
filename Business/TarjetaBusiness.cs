using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    public class TarjetaBusiness
    {
        TarjetaData tarjetadata = new TarjetaData();
        public IQueryable<TARJETA> GetTARJETAs()
        {
            return tarjetadata.GetTARJETAs();
        }

        // GET: api/TARJETAs/5
        public TARJETA GetTARJETA(int id)
        {
            TARJETA tarjeta = tarjetadata.GetTARJETA(id);
            return tarjeta;
        }

        // PUT: api/TARJETAs/5
        public void PutTARJETA(TARJETA tarjeta)
        {

            tarjetadata.PutTARJETA(tarjeta);

        }

        // POST: api/TARJETAs
        public void PostTARJETA(TARJETA tarjeta)
        {

            tarjetadata.PostTARJETA(tarjeta);

        }

        // DELETE: api/TARJETAs/5
        public void DeleteTARJETA(int id)
        {
            tarjetadata.DeleteTARJETA(id);
        }

        public bool TARJETAexists(int id)
        {
            return tarjetadata.TARJETAexists(id);
        }
        public IQueryable<TARJETA> GetTARJETAs_Cliente(int id)
        {
            return tarjetadata.GetTARJETAs_Cliente(id);
        }
    }
}
