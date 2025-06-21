using egourmetAPI.Repository.Interface;
using IzyLav.Model;
using IzyLav.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class MaquinaTipoService : IMaquinaTipoService
    {
        private readonly IMaquinaTipoRepository _maquinaTipoRepository;

        public MaquinaTipoService(IMaquinaTipoRepository maquinatipoRepository)
        {
            _maquinaTipoRepository = maquinatipoRepository;
        }

        public void Add(MaquinaTipo objTipo)
        {
            _maquinaTipoRepository.Add(objTipo);
        }

        public IEnumerable<MaquinaTipo> GetAllAsync()
        {
            return _maquinaTipoRepository.GetAll();
        }

        public MaquinaTipo GetById(int id)
        {
            return _maquinaTipoRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _maquinaTipoRepository.Remove(id);
        }

        public void Update(MaquinaTipo objMaquinaTipo)
        {
            _maquinaTipoRepository.Update(objMaquinaTipo);
        }
    }
}
