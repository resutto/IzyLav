using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeController : ControllerBase
    {
        private readonly IUnidadeService _unidadeService;
        public UnidadeController(IUnidadeService unidadeService)
        {
            _unidadeService = unidadeService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Unidade>> GetAll()
        {
            return Ok(_unidadeService.GetAllAsync());
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Unidade> GetById(int id)
        {
            return Ok(_unidadeService.GetById(id));
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] Unidade und)
        {
            try
            {
                _unidadeService.Update(und);
                return Ok("Unidade Atualizada Com Sucesso!");
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
                _unidadeService.Remove(id);
                return Ok("Unidade Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Unidade und)
        {
            try
            {
                _unidadeService.Add(und);
                return Ok("Unidade Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
