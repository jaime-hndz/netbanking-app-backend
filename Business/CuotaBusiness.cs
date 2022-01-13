using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    public class  CuotaBusiness
    {
        CuotaData cuotadata = new CuotaData();
        public IQueryable<CUOTA> GetCUOTAs()
        {
            return cuotadata.GetCUOTAs();
        }

        // GET: api/CUOTAs/5
        public CUOTA GetCUOTA(int id)
        {
            CUOTA cuota = cuotadata.GetCUOTA(id);
            return cuota;
        }

        // PUT: api/CUOTAs/5
        public void PutCUOTA(CUOTA cuota)
        {

            cuotadata.PutCUOTA(cuota);

        }

        // POST: api/CUOTAs
        public void PostCUOTA(CUOTA cuota)
        {

            cuotadata.PostCUOTA(cuota);

        }

        // DELETE: api/CUOTAs/5
        public void DeleteCUOTA(int id)
        {
            cuotadata.DeleteCUOTA(id);
        }

        public bool CUOTAexists(int id)
        {
            return cuotadata.CUOTAexists(id);
        }
    }
}
