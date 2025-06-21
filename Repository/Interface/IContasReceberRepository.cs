using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IContasReceberRepository:IRepositoryBase<ContasReceber>
    {
        public void Remove(int empresa, int contreccodigo);
        public ContasReceber GetById(int empresa, int contreccodigo);
        public IEnumerable<ContasReceber> GetAll(int empresa);

    }
}
