using EgourmetAPI.Model;
using IzyLav.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IzyLav.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {   
        private ICargoService _cargoService;
        public CargoController(ICargoService service) {
            _cargoService = service; 
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cargo>> GetAll() {
            return Ok(_cargoService.GetAllAsync());
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Cargo> GetById(int id)
        {
            return Ok(_cargoService.GetById(id));
        }

        [HttpPut]
        public ActionResult<String> Update([FromBody] Cargo cargo)
        {
            try
            {
                _cargoService.Update(cargo);
                return Ok("Cargo Atualizado Com Sucesso!");
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
                _cargoService.Remove(id);
                return Ok("Cargo Removido Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult<String> Add([FromBody] Cargo cargo)
        {
            try
            {
                _cargoService.Add(cargo);
                return Ok("Cargo Adicionado Com Sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
