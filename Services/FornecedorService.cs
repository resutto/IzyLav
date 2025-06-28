using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IForcedorRepository _repositorio;

        public FornecedorService(IForcedorRepository repositorio)
        {
            _repositorio = repositorio;
        }


        public void Add(Fornecedor objFornec)
        {
            _repositorio.Add(objFornec);
        }

        public IEnumerable<Fornecedor> GetAllAsync()
        {
            return _repositorio.GetAll();
        }

        public Fornecedor GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public void Remove(int id)
        {
            _repositorio.Remove(id);
        }

        public void Update(Fornecedor objFornec)
        {
            _repositorio.Update(objFornec);
        }
    }
}
