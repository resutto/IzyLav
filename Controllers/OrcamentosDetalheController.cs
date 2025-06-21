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
    public class OrcamentosDetalheController : ControllerBase
    {
        private readonly IOrcamentosDetalheService _orcamentosDetalheService;
        public OrcamentosDetalheController(IOrcamentosDetalheService orcamentosDetalheService)
        {
            _orcamentosDetalheService = orcamentosDetalheService;
        }

        [Route("{empresa}/{orcamento}/{ano}")]
        [HttpGet]
        public ActionResult<IEnumerator<OrcamentosDetalhe>> GetAll(int empresa, int orcamento, string ano)
        {
            return Ok(_orcamentosDetalheService.GetAllAsync(empresa, ano, orcamento));
        }
        
        [Route("{empresa}/{orcamento}/{ano}/{detalhe}")]
        [HttpGet]
        public ActionResult<OrcamentosDetalhe> GetAll(int empresa, int orcamento, string ano, int detalhe)
        {
            return Ok(_orcamentosDetalheService.GetById(empresa,orcamento,detalhe,ano));
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] OrcamentosDetalhe OrcDet)
        {
            try
            {
                _orcamentosDetalheService.Add(OrcDet);
                return Ok("Item Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] OrcamentosDetalhe OrcDet)
        {
            try
            {
                _orcamentosDetalheService.Update(OrcDet);
                return Ok("Item Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{empresa}/{orcamento}/{ano}/{detalhe}")]
        [HttpDelete]
        public ActionResult<String> Remover(int empresa, int orcamento, string ano, int detalhe)
        {
            try
            {
                _orcamentosDetalheService.Remove(empresa,orcamento,ano,detalhe);

                return Ok("Item Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}