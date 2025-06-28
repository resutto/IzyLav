using Autofac.Core;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaservice;
        public FamiliaController(IFamiliaService familiaservice)
        {
            _familiaservice = familiaservice;
        }

        [Route("{grupo}")]
        [HttpGet]
        public ActionResult<IEnumerable<Familia>> GetAll(int grupo)
        {
            return Ok(_familiaservice.GetAll(grupo));
        }


        [Route("{grupo}/{familia}")]
        [HttpGet]
        public ActionResult<Familia> GetById(int grupo, int familia)
        {
            return Ok(_familiaservice.GetById(grupo,familia));
        }

        public ActionResult<String> Update([FromBody] Familia familia)
        {
            try
            {
                _familiaservice.Update(familia);
                return Ok("Familia Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{grupo}/{familia}")]
        [HttpDelete]
        public ActionResult<String> Remover(int grupo, int familia)
        {
            try
            {
                _familiaservice.Remove(grupo,familia);
                return Ok("Familia Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Familia familia)
        {
            try
            {
                _familiaservice.Add(familia);
                return Ok("Familia Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
