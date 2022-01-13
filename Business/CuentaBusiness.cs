using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CuentaBusiness
    {
        CuentaData cuentadata = new CuentaData();
        public IQueryable<CUENTA> GetCUENTAs()
        {
            return cuentadata.GetCUENTAs();
        }

        // GET: api/CUENTAs/5
        public CUENTA GetCUENTA(int id)
        {
            CUENTA cuenta = cuentadata.GetCUENTA(id);
            return cuenta;
        }

        // PUT: api/CUENTAs/5
        public void PutCUENTA(CUENTA cuenta)
        {

            cuentadata.PutCUENTA(cuenta);

        }

        public void PutCUENTATRANSACCION(CUENTA cuenta, float val, float newval)
        {
            TRANSACCION tran = new TRANSACCION();
            if (newval > val)
            {
                tran.TIPO = "Deposito";
            }
            else
            {
                tran.TIPO = "Retiro";
            }
            tran.ID_CUENTA = cuenta.ID_CUENTA.ToString();
            tran.MONTO = val;
            tran.FECHA_CREACION = new DateTime();

            TransaccionData tr = new TransaccionData();
            tr.PostTRANSACCION(tran);
            cuentadata.PutCUENTA(cuenta);

        }

        // POST: api/CUENTAs
        public void PostCUENTA(CUENTA cuenta)
        {

            cuentadata.PostCUENTA(cuenta);

        }

        // DELETE: api/CUENTAs/5
        public void DeleteCUENTA(int id)
        {
            cuentadata.DeleteCUENTA(id);
        }

        public bool CUENTAexists(int id)
        {
            return cuentadata.CUENTAexists(id);
        }

        public IQueryable<CUENTA> GetCUENTAs_Cliente(int id)
        {
            return cuentadata.GetCUENTAs_Cliente(id);
        }
    }
}
