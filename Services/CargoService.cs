using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        public CargoService(ICargoRepository rep) {
            _cargoRepository = rep;
        }
        public void Add(Cargo objCargo)
        {
            _cargoRepository.Add(objCargo);
        }

        public IEnumerable<Cargo> GetAllAsync()
        {
            return _cargoRepository.GetAll();
        }

        public Cargo GetById(int id)
        {
            return _cargoRepository.GetById(id);
        }

        public void Remove(int id)
        {
            _cargoRepository.Remove(id);
        }

        public void Update(Cargo objCargo)
        {
            _cargoRepository.Update(objCargo);
        }
    }
}
