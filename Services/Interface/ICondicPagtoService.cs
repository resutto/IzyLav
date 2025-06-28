using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ICondicPagtoService:IServiceBase<CondicPagto>
    {
        public IEnumerable<CondicPagto> GetAllAsync(string tipo);
    }
}
