using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAplicController : ControllerBase
    {
        private readonly IUsuarioAplicService _servico;
        public UsuarioAplicController(IUsuarioAplicService servico)
        {
            _servico = servico;
        }

        [Route("{Grupo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Usuaplic>> GetAll(int Grupo)
        {
            return Ok(_servico.GetAllAsync(Grupo));
        }

        [Route("{Grupo}/{Aplicacao}")]
        [HttpGet]
        public ActionResult<Usuaplic> GetById(int Grupo, string Aplicacao)
        {
            return Ok(_servico.GetById(Grupo,Aplicacao));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Usuaplic usuaplic)
        {
            try
            {
                _servico.Update(usuaplic);
                return Ok("Grupo/Aplicação Atualizados Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{Grupo}/{Aplicacao}")]
        [HttpDelete]
        public ActionResult<String> Remover(int Grupo, string Aplicacao)
        {
            try
            {
                _servico.Remove(Grupo,Aplicacao);
                return Ok("Grupo/Aplicação Removidos Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Usuaplic usuaplic)
        {
            try
            {
                _servico.Add(usuaplic);
                return Ok("Grupo/Aplicação Adicionados Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
