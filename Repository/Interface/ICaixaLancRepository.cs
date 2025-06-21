using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ICaixaLancRepository : IRepositoryBase<CaixaLanc>
    {
        public void Remove(int empresa, int lancamento);
        public CaixaLanc GetById(int empresa, int lancamento);
        public IEnumerable<CaixaLanc> GetAll(int empresa);
    }
}
