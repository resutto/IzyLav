using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IContasRepository:IRepositoryBase<Contas>
    {
        public void Remove(string id);
        public Contas GetById(string id);
    }
}
