using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;
using Model;

namespace IzyLav.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        public ProdutoService(IProdutoRepository rep)
        {
            _repository = rep;
        }

        public void Add(Produto objProduto)
        {
            _repository.Add(objProduto);
        }

        public IEnumerable<Produto> GetAllAsync(int empresa)
        {
            return _repository.GetAll(empresa);
        }

        public IEnumerable<Produto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Produto GetById(string produto, int empresa)
        {
            return _repository.GetByProCodigoeEmpresa(produto,empresa);
        }

        public Produto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduto(string produto, int empresa)
        {
            _repository.RemoveProduto(produto, empresa);
        }

        public void Update(Produto objProduto)
        {
            _repository.Update(objProduto);
        }

        public IEnumerable<Produto> GetPorGrupo(int empCodigo, int grupoCodigo)
        {
            return _repository.GetPorGrupo(empCodigo, grupoCodigo);
        }
        public IEnumerable<Produto> GetPorNome(int empCodigo, String nomeProd)
        {
            return _repository.GetPorNome(empCodigo, nomeProd);

        }

    }
}
