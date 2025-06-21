using egourmetAPI.Controllers;
using egourmetAPI.Service.Interface;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace IzyLav.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaquinaTipoController : Controller
    {
        private readonly IMaquinaTipoService _servico;
        private readonly ILogger<MaquinaTipoController> _logger;

        public MaquinaTipoController(IMaquinaTipoService rep, ILogger<MaquinaTipoController> logger)
        {
            _servico = rep;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MaquinaTipo>> GetAll()
        {
            return Ok(_servico.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<MaquinaTipo> GetById(int id)
        {
            return Ok(_servico.GetById(id));
        }
        //Mudar aqui
        [HttpPut]
        public ActionResult<String> Update([FromBody] MaquinaTipo maquinatipo)
        {
            try
            {
                _servico.Update(maquinatipo);
                return Ok("Tipo da Maquina Atualizada Com Sucesso!");
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
                return Ok("Tipo da Maquina Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] MaquinaTipo maquinatipo)
        {
            try
            {
                _servico.Add(maquinatipo);
                return Ok("Tipo da Maquina Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
