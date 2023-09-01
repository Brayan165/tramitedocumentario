using AutoMapper;
using Bussnies;
using IBussnies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestResponseModel;
using System.Net;
using UtilSecurity;

namespace ApiWebPage.Controllers
{
    /// <summary>
    /// METODOS PARA INICIAR SESIÓN
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        /*INYECCIÓN DE DEPENDECIAS*/
        #region DECLARACIÓN DE VARIABLES Y CONSTRUCTOR
        private readonly IAuthBussnies _authBussnies;
        private readonly IMapper _mapper;
        
        public AuthController(IMapper mapper)
        {
            _mapper = mapper;
            _authBussnies = new AuthBussnies(mapper);
        }

        #endregion DECLARACIÓN DE VARIABLES Y CONSTRUCTOR


        /// <summary>
        /// Valida que el servicio este activo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Get()
        {
            return Ok(true);
        }

        /// <summary>
        /// Metodo para realizar el inicio de sesión
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(LoginResponse))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError, Type = typeof(GenericResponse))]
        public IActionResult Login([FromBody] LoginRequest request)
        {

            LoginResponse loginResponse = _authBussnies.Login(request);

            
            //02 validar que la clave ENCRIPTADA SEA CORRECTA
            //03 ALISTAR NUESTRO RESPONSE
            //04 GENERAR NUESTRO TOKEN




            return Ok(loginResponse);
        }


    }
}