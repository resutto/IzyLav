using Autofac.Core;
using EgourmetAPI.Helpers;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegGrupoController : ControllerBase
    {
        private readonly ISegGrupoService _segGrupoService;
        public SegGrupoController(ISegGrupoService service)
        {
            _segGrupoService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SegGrupo>> GetAll()
        {
            return Ok(_segGrupoService.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<SegGrupo> GetById(int id)
        {
            return Ok(_segGrupoService.GetById(id));
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] SegGrupo seggrupo)
        {
            try
            {
                _segGrupoService.Update(seggrupo);
                return Ok("Grupo de Segurança Atualizado Com Sucesso!");
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
                _segGrupoService.Remove(id);
                return Ok("Grupo de Segurança Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] SegGrupo seggrupo)
        {
            try
            {
                _segGrupoService.Add(seggrupo);
                return Ok("Grupo de Segurança Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
