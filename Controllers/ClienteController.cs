using Autofac.Core;
using egourmetAPI.Model;
using EgourmetAPI.Model;
using IzyLav.Services;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [Route("{empCodigo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> GetAllClientesPorEmpresa(int empCodigo)
        {
            return Ok(_clienteService.GetAllClientesPorEmpresa(empCodigo));
        }

        [Route("{id}/{empCodigo}")]
        [HttpGet]
        public ActionResult<Cliente> GetByIdeEmpresa(int id, int empCodigo)
        {
            return Ok(_clienteService.GetByIdeEmpresa(id, empCodigo));
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.Add(cliente);
                return Ok("Cliente Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Cliente cliente)
        {
            try
            {
                _clienteService.Update(cliente);
                return Ok("Cliente Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("{id}/{empCodigo}")]
        [HttpDelete]
        public ActionResult<String> Remover(int id, int empCodigo)
        {
            try
            {
                _clienteService.RemovePorEmpresa(id, empCodigo);
                return Ok("Cliente Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}