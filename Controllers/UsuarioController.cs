using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService servico) {
            _usuarioService = servico;
        }
        [Route("{emp_Codigo}")]
        [HttpGet]
        [Authorize (Roles ="Administrador")]
        public ActionResult<IEnumerable<Usuario>> GetAll( int emp_Codigo)
        {
            return Ok(_usuarioService.GetAllAsync(emp_Codigo));
        }
        [Route("{userId}/{emp_Codigo}")]
        [HttpGet]
        public ActionResult<Usuario> GetById(string userId, int emp_Codigo)
        {
            return Ok(_usuarioService.GetById(userId,emp_Codigo));
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioService.Add(usuario);
                return Ok("Usuário Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{userId}/{emp_Codigo}")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public ActionResult<String> Remover(string userId, int emp_Codigo)
        {
            try
            {
                _usuarioService.Remove(userId,emp_Codigo);
                return Ok("Usuário Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioService.Update(usuario);
                return Ok("Usuário Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
