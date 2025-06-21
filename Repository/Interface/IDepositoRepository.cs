using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IDepositoRepository:IRepositoryBase<Deposito>
    {
        public void Remove(int codigo, int empresa);
        public IEnumerable<Deposito> GetAll(int empresa);
        public Deposito GetById(int codigo, int empresa);


    }
}
