using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetorController : ControllerBase
    {
        private readonly ISetorService _servico;

        public SetorController(ISetorService servico)
        {
            _servico = servico;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Setor>> GetAll()
        {
            return Ok(_servico.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Setor> GetById(int id)
        {
            return Ok(_servico.GetById(id));
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] Setor setor)
        {
            try
            {
                _servico.Update(setor);
                return Ok("Setor Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<String> Remover(int id)
        {
            try
            {
                _servico.Remove(id);
                return Ok("Setor Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Setor setor)
        {
            try
            {
                _servico.Add(setor);
                return Ok("Setor Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
