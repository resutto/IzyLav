using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IClienteService:IServiceBase<Cliente>
    {
        public IEnumerable<Cliente> GetAllClientesPorEmpresa(int empCodigo);
        public Cliente GetByIdeEmpresa(int id, int empCodigo);
        public void RemovePorEmpresa(int id, int empCodigo);
    }
}
