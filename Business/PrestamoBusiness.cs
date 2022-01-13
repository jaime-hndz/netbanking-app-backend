using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Business
{
    public class  PrestamoBusiness
    {
        PrestamoData prestamodata = new PrestamoData();
        public IQueryable<PRESTAMO> GetPRESTAMOs()
        {
            return prestamodata.GetPRESTAMOs();
        }

        // GET: api/PRESTAMOs/5
        public PRESTAMO GetPRESTAMO(int id)
        {
            PRESTAMO prestamo = prestamodata.GetPRESTAMO(id);
            return prestamo;
        }

        // PUT: api/PRESTAMOs/5
        public void PutPRESTAMO(PRESTAMO prestamo)
        {

            prestamodata.PutPRESTAMO(prestamo);

        }

        public void PutPRESTAMOCUOTA(PRESTAMO prestamo, float val)
        {
            CUOTA cuo = new CUOTA();
            cuo.ID_PRESTAMO = prestamo.ID_PRESTAMO.ToString();
            cuo.MONTO = val;
            cuo.FECHA_CREACION = new DateTime();

            CuotaData cuda = new CuotaData();
            cuda.PostCUOTA(cuo);
            prestamodata.PutPRESTAMO(prestamo);

        }

        // POST: api/PRESTAMOs
        public void PostPRESTAMO(PRESTAMO prestamo)
        {

            prestamodata.PostPRESTAMO(prestamo);

        }

        // DELETE: api/PRESTAMOs/5
        public void DeletePRESTAMO(int id)
        {
            prestamodata.DeletePRESTAMO(id);
        }

        public bool PRESTAMOexists(int id)
        {
            return prestamodata.PRESTAMOexists(id);
        }

        public IQueryable<PRESTAMO> GetPRESTAMOs_Cliente(int id)
        {
            return prestamodata.GetPRESTAMOs_Cliente(id);
        }
    }
}
