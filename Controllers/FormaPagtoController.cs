using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagtoController : ControllerBase
    {
        private readonly IFormaPagtoService _service;
        public FormaPagtoController(IFormaPagtoService service)
        {
            _service = service;
        }

        [Route("todos/{tipo}")]
        [HttpGet]
        public ActionResult<IEnumerator<FormaPagto>> GetAll(string tipo) { 
            return Ok(_service.GetAllAsync(tipo.ToUpper()));
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<FormaPagto> GetById(int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] FormaPagto forma)
        {
            try
            {
                _service.Update(forma);
                return Ok("Condição de Pagamento Atualizada Com Sucesso!");
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
                return Ok("Condição de Pagamento Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] FormaPagto forma)
        {
            try
            {
                _service.Add(forma);
                return Ok("Condição de Pagamento Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
