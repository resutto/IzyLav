using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        public IEnumerable<Cliente> GetAllClientesPorEmpresa(int empCodigo);
        public Cliente GetByIdeEmpresa(int id, int empCodigo);
        public void RemovePorEmpresa(int id, int empCodigo);
   }
}