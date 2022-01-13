using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UsuarioData
    {
        private internet_bankingEntities db = new internet_bankingEntities();

        // GET: api/USUARIOs
        public IQueryable<USUARIO> GetUSUARIOs()
        {
            return db.USUARIOs;
        }

        // GET: api/USUARIOs/5
        public USUARIO GetUSUARIO(int id)
        {
            USUARIO usuario = db.USUARIOs.Find(id);
            if (usuario == null)
            {
                return null;
            }

            return usuario;
        }

        // PUT: api/USUARIOs/5
        public void PutUSUARIO(USUARIO usuario)
        {

            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();

        }

        // POST: api/USUARIOs
        public void PostUSUARIO(USUARIO usuario)
        {

            db.USUARIOs.Add(usuario);
            db.SaveChanges();

        }

        // DELETE: api/USUARIOs/5
        public void DeleteUSUARIO(int id)
        {
            USUARIO usuario = db.USUARIOs.Find(id);
            db.USUARIOs.Remove(usuario);
            db.SaveChanges();
        }

        public bool USUARIOexists(int id)
        {
            return db.USUARIOs.Count(e => e.ID_USUARIO == id) > 0;
        }

        public IQueryable<USUARIO> log_in(String user, String pass)
        {
            return db.USUARIOs.Where(x => x.USUARIO1 ==user ).Where(x => x.CONTRA == pass);
        }

    }
}
