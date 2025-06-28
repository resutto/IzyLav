using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CfopController : ControllerBase
    {
        private readonly ICfopService _service;
        public CfopController(ICfopService service) { 
            _service = service; 
        }


        [HttpGet]
        public ActionResult<IEnumerable<Cfop>> GetAll() {
            return Ok(_service.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Cfop> GetById(string id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Cfop cfop)
        {
            try
            {
                _service.Update(cfop);
                return Ok("CFOP Atualizada Com Sucesso!");
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
                return Ok("CFOP Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Cfop cfop)
        {
            try
            {
                _service.Add(cfop);
                return Ok("CFOP Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
