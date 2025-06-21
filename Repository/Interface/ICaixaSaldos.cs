using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICaixaSaldos : IRepositoryBase<CaixaSaldos>
    {
        public void Remove(int empresa, int saldoid);
        public IEnumerable<CaixaSaldos> GetAll(int empresa);

    }
}
