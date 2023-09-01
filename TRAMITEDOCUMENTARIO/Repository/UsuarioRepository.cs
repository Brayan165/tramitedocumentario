using BDTramiteDocumentarioModel;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UsuarioRepository : CRUDRepository<Usuario>, IUsuarioRepository
    {
        public Usuario ObetenerPorUsername(string username)
        {
            Usuario usuario = dbSet
                .Where(x => x.Username.ToLower() == username.ToLower())
                //ES MEDIANAMENTE OPTIMO
                //.Include(x => x.IdRolNavigation)
                //.Include(x => x.IdPersonaNavigation)

                .FirstOrDefault();

            return usuario;
        }

        public VUsuario ObetenerVistaUsername(string username)
        {
            VUsuario vUsuario = db.VUsuarios.Where(x => x.Username.ToLower() == username.ToLower()).FirstOrDefault();
            return vUsuario;
        }
    }
}
