using EgourmetAPI.Model;
using IzyLav.common;
using IzyLav.Data;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        private readonly ITokenService _tokenService;
        public LoginController(ILoginService service, ITokenService tokenService)
        {
            _service = service;
            _tokenService = tokenService;
        }

        [Route("{usuario}/{senha}")]
        [HttpGet]
        public ActionResult<string> Login(string usuario, string senha)
        {
            Usuario usuarioResult=_service.Login(usuario, Datpai.HashMD5(senha));
            if (usuarioResult != null) {
                string sbearer = _tokenService.GenerateToken(usuarioResult);
                if (sbearer=="") return Unauthorized();
                return Ok(sbearer);
            }
            else return NotFound();
        }

        [Route("aplic/{empresa}/{usuario}")]
        [HttpGet]
        [Authorize (Roles ="Administrador,Usuarios") ]
        public ActionResult<IEnumerable<UsuarioAplicacoesDTO>> Aplicacoes(string usuario, int empresa)
        {
            IEnumerable<UsuarioAplicacoesDTO> aplicacoesResult = _service.Aplicacoes(usuario,empresa);
            if (aplicacoesResult.Count()>0)
            {
                return Ok(aplicacoesResult);
            }
            else return NotFound(); 
            
        }
    }
}
