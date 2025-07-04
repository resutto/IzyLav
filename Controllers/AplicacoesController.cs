using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles="Administrador")]
    public class AplicacoesController : ControllerBase
    {
        private readonly IAplicacoesService _service;
        public AplicacoesController(IAplicacoesService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Aplicacoes>> GetAll() {
            return Ok(_service.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Aplicacoes> GetById(string id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Aplicacoes apl)
        {
            try
            {
                _service.Update(apl);
                return Ok("Aplicação Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult<String> Remover(string id)
        {
            try
            {
                _service.Remove(id);
                return Ok("Aplicação Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Aplicacoes apl)
        {
            try
            {
                _service.Add(apl);
                return Ok("Aplicação Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}

