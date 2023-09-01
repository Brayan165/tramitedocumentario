using AutoMapper;
using BDTramiteDocumentarioModel;
using IBussnies;
using IRepository;
using Repository;
using RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilSecurity;

namespace Bussnies
{
    public class AuthBussnies: IAuthBussnies
    {
        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IUsuarioBussnies _usuarioBussnies;
        private readonly IMapper _mapper;
        private readonly IRolBussnies _rolBussnies;
        private readonly UtilEncriptarDesencriptar _cripto;
        public AuthBussnies(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioBussnies = new UsuarioBussnies(mapper);
            _rolBussnies = new RolBussnies(mapper);
            _cripto = new UtilEncriptarDesencriptar();
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse result = new LoginResponse();

            //01 VALIDAMOS QUE EL USUARIO EXISTA
            VUsuario usuario = _usuarioBussnies.ObetenerVistaUsername(request.UserName);
            if(usuario == null)
            {
                return result;
            }


            //02 VALIDAMOS QUE EL USUARIO EXISTA
            //02.01 ==> proceso de encriptar un texto
            string newPassword = _cripto.AES_encriptar(request.Password);

            if(newPassword != usuario.Password)
            {
                return result;
            }

            result.Success = true;
            result.Mensaje = "LOGIN CORRECTO";

            result.Usuario = new UsuarioLoginResponse();
            result.Usuario.Id = usuario.Id;
            result.Usuario.Username = usuario.Username;
            result.Usuario.IdEstado = usuario.IdEstado;
            result.Usuario.ChangePassword = usuario.ChangePassword;
            result.Usuario.IdPersona = usuario.IdPersona;
            result.Usuario.IdentificadorCelular = "";
            result.Usuario.ChangePassword = usuario.ChangePassword;
            result.Usuario.Email = usuario.Email;
            result.Rol = new RolResponse();
            result.Rol.Id = usuario.IdRol;
            result.Rol.Codigo = usuario.RolCodigo;
            result.Rol.Descripcion = usuario.RolDescripcion;

            /*ESTE TIPO DE IMPLEMENTACIÓN NO ES LA MAS OPTIMA*/
            /*
             * VAMOS A REALIZAR CONSULTAS INDEPENDIENTES
             * _rolBussnies
             * _personaBussnies
             */

            //result.Usuario = new UsuarioLoginResponse();
            //result.Rol = new RolResponse();
            //busqueda del usuario
            //busqueda del rol
            return result;
        }
    }
}
