using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaQdeDiasController : ControllerBase
    {
        private readonly IFormaQdeDiasService _service;
        public FormaQdeDiasController(IFormaQdeDiasService service)
        {
            _service = service;
        }

        [Route("{forma}")]
        [HttpGet]
        public ActionResult<IEnumerable<FormaQdeDias>> GetAll(int forma)
        {
            return Ok(_service.GetAllAsync(forma));
        }

        [Route("{id}/{forma}")]
        [HttpGet]
        public ActionResult<FormaQdeDias> GetById(int id,int forma)
        {
            return Ok(_service.GetById(id,forma));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] FormaQdeDias formadias)
        {
            try
            {
                _service.Update(formadias);
                return Ok("Qde Dias Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}/{forma}")]
        [HttpDelete]
        public ActionResult<String> Remover(int id, int forma)
        {
            try
            {
                _service.Remove(id,forma);
                return Ok("Qde Dias Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] FormaQdeDias formadias)
        {
            try
            {
                _service.Add(formadias);
                return Ok("Qde Dias Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
