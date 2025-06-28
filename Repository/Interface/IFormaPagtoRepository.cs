using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IFormaPagtoRepository : IRepositoryBase<FormaPagto>
    {
        public IEnumerable<FormaPagto> GetAll(string tipo);

    }
}
