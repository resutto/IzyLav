using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;
        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetAll()
        {
            return Ok(_fornecedorService.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> GetById(int id)
        {
            return Ok(_fornecedorService.GetById(id));
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] Fornecedor fornec)
        {
            try
            {
                _fornecedorService.Update(fornec);
                return Ok("Fornecedor Atualizado Com Sucesso!");
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
                _fornecedorService.Remove(id);
                return Ok("Fornecedor Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Fornecedor fornec)
        {
            try
            {
                _fornecedorService.Add(fornec);
                return Ok("Fornecedor Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
