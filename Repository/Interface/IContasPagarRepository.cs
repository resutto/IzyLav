using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IContasPagarRepository:IRepositoryBase<ContasPagar>
    {
        public void Remove(int empresa, int contpagcodigo);
        public ContasPagar GetById(int empresa, int contpagcodigo);
        public IEnumerable<ContasPagar> GetAll(int empresa);

    }
}
