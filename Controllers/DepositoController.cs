using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositoController : ControllerBase
    {
        private readonly IDepositoService _depositoService;
        public DepositoController(IDepositoService depositoService)
        {
            _depositoService = depositoService;
        }

        [Route("{empresa}")]
        [HttpGet]
        public ActionResult<IEnumerator<Deposito>> GetAll(int empresa) {
            return Ok(_depositoService.GetAllAsync(empresa));
        }

        [Route("{id}/{empresa}")]
        [HttpGet]
        public ActionResult<Deposito> GetById(int id,int empresa)
        {
            return Ok(_depositoService.GetById(id,empresa));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Deposito dep)
        {
            try
            {
                _depositoService.Update(dep);
                return Ok("Depósito Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}/{empresa}")]
        [HttpDelete]
        public ActionResult<String> Remover(int id, int empresa)
        {
            try
            {
                _depositoService.Remove(id,empresa);
                return Ok("Deposito Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Deposito dep)
        {
            try
            {
                _depositoService.Add(dep);
                return Ok("Deposito Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
