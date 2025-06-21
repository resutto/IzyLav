using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface ISaldoProdutoRepository:IRepositoryBase<SaldoProduto>
    {
        public IEnumerable<SaldoProduto> GetAll(int empresa, string produto);
        public SaldoProduto GetById(int empresa, int deposito, string produto);

    }
}
