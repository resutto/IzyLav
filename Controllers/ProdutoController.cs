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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService servico)
        {
            _produtoService = servico;
        }

        [Route("{empresa}/{produto}")]
        [HttpGet]
        public ActionResult<Produto> GetById(int empresa, string produto) {
            return Ok(_produtoService.GetById(produto, empresa));
        }

        [Route("{empresa}")]
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll(int empresa)
        {
            return Ok(_produtoService.GetAllAsync(empresa));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Produto produto)
        {
            try
            {
                _produtoService.Update(produto);
                return Ok("Produto Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{empresa}/{produto}/")]
        [HttpDelete]
        public ActionResult<String> Remover(string produto, int empresa)
        {
            try
            {
                _produtoService.RemoveProduto(produto, empresa);
                return Ok("Produto Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Produto produto)
        {
            try
            {
                _produtoService.Add(produto);
                return Ok("Produto Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
