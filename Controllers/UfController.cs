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
    public class UfController : ControllerBase
    {
        private readonly IUfService _service;
        public UfController(IUfService servico) {
            _service = servico;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Uf>> GetAll()
        {
            return Ok(_service.GetAllAsync());
        }

        [Route("{Uf}")]
        [HttpGet]
        public ActionResult<Uf> GetById(string Uf)
        {
            return Ok(_service.GetById(Uf));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Uf uf)
        {
            try
            {
                _service.Update(uf);
                return Ok("UF Atualizada Com Sucesso!");
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
                return Ok("UF Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Uf uf)
        {
            try
            {
                _service.Add(uf);
                return Ok("UF Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
