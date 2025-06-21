using System.Globalization;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class SaldoProdutoService : ISaldoProdutoService
    {
        private readonly ISaldoProdutoRepository _repositorio;

        public SaldoProdutoService(ISaldoProdutoRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public void Add(SaldoProduto objSaldo)
        {
            _repositorio.Add(objSaldo);
        }

        public IEnumerable<SaldoProduto> GetAllAsync(string produto, int empresa)
        {
            return _repositorio.GetAll(empresa, produto);
        }

        public IEnumerable<SaldoProduto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public SaldoProduto GetById(string produto, int deposito, int empresa)
        {
            return _repositorio.GetById(empresa, deposito, produto);
        }

        public SaldoProduto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string produto, int deposito, int empresa)
        {
            _repositorio.Remove(empresa, deposito, produto);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SaldoProduto objSaldo)
        {
            _repositorio.Update(objSaldo);
        }
    }
}
