using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IProdutoService:IServiceBase<Produto>
    {
        public void RemoveProduto(string produto, int empresa);
        public IEnumerable<Produto> GetAllAsync(int empresa);
        public Produto GetById(string produto, int empresa);
        public IEnumerable<Produto> GetPorGrupo(int empCodigo, int grupoCodigo);
    }
}
