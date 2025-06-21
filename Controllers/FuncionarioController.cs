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
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        [Route("{emp_Codigo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> getAll(int emp_Codigo)
        {
            return Ok(_funcionarioService.GetAllAsync(emp_Codigo));
        }

        [Route("{fun_Codigo}/{emp_Codigo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Funcionario>> getById(int fun_Codigo, int emp_Codigo)
        {
            return Ok(_funcionarioService.GetById(fun_Codigo,emp_Codigo));
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] Funcionario func)
        {
            try
            {
                _funcionarioService.Add(func);
                return Ok("Funcionário Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public ActionResult<String> Update([FromBody] Funcionario func)
        {
            try
            {
                _funcionarioService.Update(func);
                return Ok("Funcionário Atualizado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{funcionario}/{empresa}")]
        [HttpDelete]
        public ActionResult<String> Remover(int funcionario, int empresa)
        {
            try
            {
                _funcionarioService.Remove(funcionario,empresa);
                return Ok("Funcionário Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
