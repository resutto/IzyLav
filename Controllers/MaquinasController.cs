using egourmetAPI.Model;
using IzyLav.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class MaquinasController : ControllerBase
    {
        private readonly IMaquinasService _servico;
        public MaquinasController(IMaquinasService servico)
        {
            _servico = servico;
        }
        [Route("{id}")]
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult<IEnumerable<Maquinas>> GetAll(int id) { 
          return Ok(_servico.GetAll(id));
        }

        [Route("{id}/{empCodigo}")]
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public ActionResult<Maquinas> GetById(string id, int empCodigo)
        {
            return _servico.GetById(id, empCodigo);
        }

        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public ActionResult<String> Update([FromBody] Maquinas maquina)
        {
            try
            {
                _servico.Update(maquina);
                return Ok("Maquina Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [Route("{id}/{empCodigo}")]
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public ActionResult<String> Remover(string id, int empCodigo)
        {
            try
            {
                _servico.Remove(id,empCodigo);
                return Ok("Maquina Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public ActionResult<String> Add([FromBody] Maquinas maquina)
        {
            try
            {
                _servico.Add(maquina);
                return Ok("Maquina Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
