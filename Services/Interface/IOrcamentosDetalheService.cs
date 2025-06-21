using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IOrcamentosDetalheService:IServiceBase<OrcamentosDetalhe>
    {
        public IEnumerable<OrcamentosDetalhe> GetAllAsync(int empCodigo, string ano, int orcCodigo);
        public OrcamentosDetalhe GetById(int empresa, int orcamento, int detalhe, string ano);

        public void Remove(int empresa, int orcamento, string ano, int detalhe);

    }
}
