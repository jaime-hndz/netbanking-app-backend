using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusiness
    {
        UsuarioData usuariodata = new UsuarioData();
        public IQueryable<USUARIO> GetUSUARIOs()
        {
            return usuariodata.GetUSUARIOs();
        }

        // GET: api/USUARIOs/5
        public USUARIO GetUSUARIO(int id)
        {
            USUARIO usuario = usuariodata.GetUSUARIO(id);
            return usuario;
        }

        // PUT: api/USUARIOs/5
        public void PutUSUARIO(USUARIO usuario)
        {

            usuariodata.PutUSUARIO(usuario);

        }

        // POST: api/USUARIOs
        public void PostUSUARIO(USUARIO usuario)
        {

            usuariodata.PostUSUARIO(usuario);

        }

        // DELETE: api/USUARIOs/5
        public void DeleteUSUARIO(int id)
        {
            usuariodata.DeleteUSUARIO(id);
        }

        public bool USUARIOexists(int id)
        {
            return usuariodata.USUARIOexists(id);
        }

        public IQueryable<USUARIO> Log_in(String user, String pass)
        {
            return usuariodata.log_in(user, pass);
        }
    }
}
