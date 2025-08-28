using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentosController : ControllerBase
    {
        private readonly IOrcamentosService _servico;
        public OrcamentosController(IOrcamentosService servico) { 
            _servico = servico;
        }
        [Route("{empresa}")]
        [HttpGet]
        public ActionResult<IEnumerable<Orcamentos>> GetAll(int empresa)
        {
            return Ok(_servico.GetAllAsync(empresa));
        }

        [Route("pedidos/{empresa}/{ClienteCodigo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Orcamentos>> GetAllFromClient(int empresa, int ClienteCodigo)
        {
            return Ok(_servico.GetAllFromClient(empresa,ClienteCodigo));
        }
        

        [Route("{empresa}/{orcCodigo}/{ano}")]
        [HttpGet]
        public ActionResult<Orcamentos> GetById(int empresa, int orcCodigo, string ano)
        {
            return Ok(_servico.GetById(empresa, orcCodigo, ano));
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] Orcamentos orc)
        {
            try
            {
                String resultado=_servico.Add(orc);
                return Ok(resultado+" Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{empresa}/{orcCodigo}/{ano}")]
        [HttpDelete]
        public ActionResult<String> Remover(int empresa, int orcCodigo, string ano)
        {
            try
            {
                _servico.Remove(empresa,orcCodigo,ano);
                return Ok("Pedido Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Orcamentos orc)
        {
            try
            {
                _servico.Update(orc);
                return Ok("Pedido Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
