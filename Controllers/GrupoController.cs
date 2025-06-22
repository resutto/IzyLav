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
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoService _grupoService;
        public GrupoController(IGrupoService serv)
        {
            _grupoService = serv;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Cargo>> GetAll() {
            return Ok(_grupoService.GetAllAsync());
        }
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Cargo> GetById(int id)
        {
            return Ok(_grupoService.GetById(id));
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] Grupo grupo)
        {
            try
            {
                _grupoService.Update(grupo);
                return Ok("Grupo Atualizado Com Sucesso!");
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
                _grupoService.Remove(id);
                return Ok("Grupo Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Grupo grupo)
        {
            try
            {
                _grupoService.Add(grupo);
                return Ok("Grupo Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
