using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioFuncionarioController : ControllerBase
    {
        private readonly IUsuarioFuncionarioService _servico;
        public UsuarioFuncionarioController(IUsuarioFuncionarioService servico)
        {
            _servico = servico;
        }

        [Route("{empresa}/{usuario}")]
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioFuncionario>> GetAll(int empresa, string usuario)
        {
            return Ok(_servico.GetAll(empresa,usuario));
        }
    }
}
