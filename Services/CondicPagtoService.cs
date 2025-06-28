using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class CondicPagtoService : ICondicPagtoService
    {
        private readonly ICondicPagtoRepository _repositorio;
        public CondicPagtoService(ICondicPagtoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(CondicPagto objCondic)
        {
            _repositorio.Add(objCondic);
        }

        public IEnumerable<CondicPagto> GetAllAsync(string tipo)
        {
            return _repositorio.GetAll(tipo);
        }

        public IEnumerable<CondicPagto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public CondicPagto GetById(int id)
        {
            return _repositorio.GetById(id);
        }

        public void Remove(int id)
        {
            _repositorio.Remove(id);
        }

        public void Update(CondicPagto objCondic)
        {
            _repositorio.Update(objCondic);
        }
    }
}
