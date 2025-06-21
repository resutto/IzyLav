using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ISaldoProdutoService:IServiceBase<SaldoProduto>
    {
        public IEnumerable<SaldoProduto> GetAllAsync(string produto, int empresa);
        public SaldoProduto GetById(string produto, int deposito, int empresa);
    }
}
