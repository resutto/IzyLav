using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class UnidadeService : IUnidadeService
    {
        private readonly IUnidadeRepository _unidadeRepository;
        public UnidadeService(IUnidadeRepository rep) {
            _unidadeRepository = rep;
        }
        public void Add(Unidade objUnidade)
        {
            _unidadeRepository.Add(objUnidade);
        }

        public IEnumerable<Unidade> GetAllAsync()
        {
            return _unidadeRepository.GetAll();
        }

        public Unidade GetById(int id)
        {
            return _unidadeRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _unidadeRepository.Remove(id);
        }

        public void Update(Unidade objUnid)
        {
            _unidadeRepository.Update(objUnid);
        }
    }
}
