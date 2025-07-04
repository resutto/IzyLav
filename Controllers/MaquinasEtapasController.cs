using Autofac.Core;
using egourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class MaquinasEtapasController : ControllerBase
    {
       private readonly IMaquinasEtapasService _maquinasEtapaservice;
       public MaquinasEtapasController(IMaquinasEtapasService service)
        {
            _maquinasEtapaservice = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MaquinasEtapas>> GetAll()
        {
            return Ok(_maquinasEtapaservice.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<MaquinasEtapas> GetById(int id)
        {
            return Ok(_maquinasEtapaservice.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] MaquinasEtapas maquinasetapas)
        {
            try
            {
                _maquinasEtapaservice.Update(maquinasetapas);
                return Ok("Etapa Atualizada Com Sucesso!");
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
                _maquinasEtapaservice.Remove(id);
                return Ok("Etapa Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] MaquinasEtapas maquinaetapa)
        {
            try
            {
                _maquinasEtapaservice.Add(maquinaetapa);
                return Ok("Etapa Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
