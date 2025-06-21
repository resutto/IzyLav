using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class AplicacoesService : IAplicacoesService
    {
        private readonly IAplicacoesRepository _repositorio;
        public AplicacoesService(IAplicacoesRepository rep) {
            _repositorio = rep;  
        }
        public void Add(Aplicacoes objApl)
        {
            _repositorio.Add(objApl);
        }
        public IEnumerable<Aplicacoes> GetAllAsync()
        {
            return _repositorio.GetAll();
        }
        public Aplicacoes GetById(string id) {
            return _repositorio.GetById(id);
        }
        public Aplicacoes GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            _repositorio.Remove(id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Aplicacoes objApl)
        {
            _repositorio.Update(objApl);
        }
    }
}
