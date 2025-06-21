using System.Numerics;
using egourmetAPI.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;

namespace egourmetAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _servico;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(IEmpresaService rep, ILogger<EmpresaController> logger)
        {
            _servico = rep;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empresa>> GetAll()
        {
            return Ok(_servico.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Empresa> GetById(int id)
        {
            return Ok(_servico.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody]Empresa emp)
        {
            try
            {
                _servico.Update(emp);
                return Ok("Empresa Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
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
                return Ok("Empresa Removida Com Sucesso!");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] Empresa emp)
        {
            try
            {
                _servico.Add(emp);
                return Ok("Empresa Adicionada Com Sucesso!");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
        
    } 
}