using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CondicPagtoController : ControllerBase
    {
        private readonly ICondicPagtoService _service;
        public CondicPagtoController(ICondicPagtoService service) { 
            _service=service;
        }
        
        [Route("todos/{tipo}")]
        [HttpGet]
        public ActionResult<IEnumerable<CondicPagto>> GetAll(string tipo)
        {
            return Ok(_service.GetAllAsync(tipo.ToUpper()));
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<CondicPagto> GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] CondicPagto condic)
        {
            try
            {
                _service.Update(condic);
                return Ok("Condição de Pagto Atualizada Com Sucesso!");
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
                _service.Remove(id);
                return Ok("Condição de Pagto Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] CondicPagto condic)
        {
            try
            {
                _service.Add(condic);
                return Ok("Condição de Pagto Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
