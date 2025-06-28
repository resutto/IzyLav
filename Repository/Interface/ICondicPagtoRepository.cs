using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICondicPagtoRepository : IRepositoryBase<CondicPagto>
    {
        public IEnumerable<CondicPagto> GetAll(string tipo);
    }
}
