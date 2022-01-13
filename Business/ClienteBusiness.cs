using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ClienteBusiness
    {
        ClienteData clientedata = new ClienteData();
        public IQueryable<CLIENTE> GetCLIENTEs()
        {
            return clientedata.GetCLIENTEs();
        }

        // GET: api/CLIENTEs/5
        public CLIENTE GetCLIENTE(int id)
        {
            CLIENTE cliente = clientedata.GetCLIENTE(id);
            return cliente;
        }

        // PUT: api/CLIENTEs/5
        public void PutCLIENTE(CLIENTE cliente)
        {

            clientedata.PutCLIENTE(cliente);

        }

        // POST: api/CLIENTEs
        public void PostCLIENTE(CLIENTE cliente)
        {

            clientedata.PostCLIENTE(cliente);

        }

        // DELETE: api/CLIENTEs/5
        public void DeleteCLIENTE(int id)
        {
            clientedata.DeleteCLIENTE(id);
        }

        public bool CLIENTEexists(int id)
        {
            return clientedata.CLIENTEexists(id);
        }
    }
}
