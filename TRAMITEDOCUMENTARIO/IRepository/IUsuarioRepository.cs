using BDTramiteDocumentarioModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IUsuarioRepository : ICRUDRepository<Usuario>
    {
        Usuario ObetenerPorUsername(string username);
        VUsuario ObetenerVistaUsername(string username);
    }
}
