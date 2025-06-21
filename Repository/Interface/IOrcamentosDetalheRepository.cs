using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IOrcamentosDetalheRepository:IRepositoryBase<OrcamentosDetalhe>
    {
        public OrcamentosDetalhe GetById(int empresa, int orcamento, int detalhe, string ano);
        public void Remove(int empresa, int orcamento, string ano, int detalhe);
        public IEnumerable<OrcamentosDetalhe> GetAll(int empCodigo, string ano, int orcCodigo);

    }
}
