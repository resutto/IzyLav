using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditosController : ControllerBase
    {
        private readonly ICreditosService _creditosService;

        public CreditosController(ICreditosService creditosService)
        {
            _creditosService = creditosService;
        }

        
        [Route("{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<Creditos>> GetAll(int id)
        {
            try
            {
                return Ok(_creditosService.GetAllAsync1(id));
            }
            catch (Exception ex) {
                return BadRequest(ex.Message); 
            }
        }
        
        [Route("Livres/{empCodigo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Creditos>> GetTicketsCompradosLivres(int empCodigo)
        {
            try
            {
                return Ok(_creditosService.GetTicketsCompradosLivres(empCodigo));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}/{empCodigo}/{ano}")]
        [HttpGet]
        public ActionResult<Creditos> GetCredito(int id, int empCodigo, string ano)
        {
            try
            {
                return Ok(_creditosService.GetById(id,empCodigo,ano));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("{id}/{empCodigo}/{ano}/{maquina}")]
        [HttpGet]
        public ActionResult<String> ConsumirCredito(int id, int empCodigo, string ano, string maquina)
        {
            try
            {
                _creditosService.ConsumirCreditoMaquina(empCodigo, id, ano, maquina);
                return Ok("Crédito Inserido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
