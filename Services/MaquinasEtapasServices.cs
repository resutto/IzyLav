using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class MaquinasEtapasServices : IMaquinasEtapasService
    {
        private readonly IMaquinasEtapas _maquinasEtapasRepository;

        public MaquinasEtapasServices(IMaquinasEtapas rep)
        {
            _maquinasEtapasRepository = rep;
        }
        public void Add(MaquinasEtapas objMaquinasEtapas)
        {
            _maquinasEtapasRepository.Add(objMaquinasEtapas);
        }

        public IEnumerable<MaquinasEtapas> GetAllAsync()
        {
            return _maquinasEtapasRepository.GetAll();
        }

        public MaquinasEtapas GetById(int id)
        {
            return _maquinasEtapasRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _maquinasEtapasRepository.Remove(id);   
        }

        public void Update(MaquinasEtapas objMaquinasEtapas)
        {
            _maquinasEtapasRepository.Update(objMaquinasEtapas);
        }
    }
}
