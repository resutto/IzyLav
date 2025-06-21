using EgourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldoProdutoController : ControllerBase
    {
        private readonly ISaldoProdutoService _servico;
        public SaldoProdutoController(ISaldoProdutoService servico)
        {
            _servico = servico;
        }

        [Route("{empresa}/{produto}")]
        [HttpGet]
        public ActionResult<IEnumerable<SaldoProduto>> GetAll(int empresa, string produto)
        {
            return Ok(_servico.GetAllAsync(produto,empresa));
        }

        [Route("{empresa}/{produto}/{deposito}")]
        [HttpGet]
        public ActionResult<IEnumerable<SaldoProduto>> GetById(int empresa, string produto, int deposito)
        {
            return Ok(_servico.GetById( produto, deposito, empresa ));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] SaldoProduto saldo)
        {
            try
            {
                _servico.Update(saldo);
                return Ok("Saldo/Produto Atualizado Com Sucesso!");
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
                _servico.Remove(id);
                return Ok("Saldo/Produto Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] SaldoProduto saldo)
        {
            try
            {
                _servico.Add(saldo);
                return Ok("Saldo/Produto Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
