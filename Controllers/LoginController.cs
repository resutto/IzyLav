using EgourmetAPI.Model;
using IzyLav.common;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [Route("{usuario}/{senha}")]
        [HttpGet]
        public ActionResult<Usuario> Login(string usuario, string senha)
        {
            return Ok(_service.Login(usuario, Datpai.HashMD5(senha)));
        }
    }
}
