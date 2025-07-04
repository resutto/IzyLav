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
    [Authorize(Roles = "Administrador")]
    public class MaquinasExecucaoController : ControllerBase
    {
        private readonly IMaquinasExecucaoService _servico;
        public MaquinasExecucaoController(IMaquinasExecucaoService serv)
        {
            _servico = serv;
        }
        [Route("{empresa}/{idCred}/{idAno}/{idLanc}")]
        [HttpGet]
        public ActionResult<IEnumerable<MaquinasExecucao>> GetAll(int empresa, int idCred, string idAno, int idLanc)
        {
            return Ok(_servico.GetAllAsync(empresa,idCred,idAno, idLanc));
        }

        [Route("{empresa}/{idCred}/{idAno}/{idLanc}/{Sequencial}")]
        [HttpGet]
        public ActionResult<MaquinaTipo> GetById(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            return Ok(_servico.GetById(empresa, idCred, idAno, idLanc, Sequencial));
        }

        [HttpPost]
        public ActionResult<String> Add([FromBody] MaquinasExecucao maquinaexecucao)
        {
            try
            {
                _servico.Add(maquinaexecucao);
                return Ok("Etapa Adicionada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] MaquinasExecucao maquinaexecucao)
        {
            try
            {
                _servico.Update(maquinaexecucao);
                return Ok("Etapa Atualizada Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{empresa}/{idCred}/{idAno}/{idLanc}/{Sequencial}")]
        [HttpDelete]
        public ActionResult<String> Remove(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            try
            {
                _servico.Remove(empresa,idCred,idAno,idLanc,Sequencial);
                return Ok("Etapa Removida Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}