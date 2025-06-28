using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IFormaPagtoService:IServiceBase<FormaPagto>
    {
        public IEnumerable<FormaPagto> GetAllAsync(string tipo);

    }
}
