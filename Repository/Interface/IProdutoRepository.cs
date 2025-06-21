using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;
using Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IProdutoRepository:IRepositoryBase<Produto>
    {
        public Produto GetByProCodigoeEmpresa(string produto, int empresa);
        ResponseMessage Adicionar(Produto produto);
        public void RemoveProduto(Produto produto);

    }
}
