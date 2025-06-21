using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using FirebirdSql.Data.FirebirdClient;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class MaquinasService : IMaquinasService
    {
        private readonly IMaquinasRepository _maquinasRepository;
        public MaquinasService(IMaquinasRepository rep)
        {
            _maquinasRepository = rep;
        }
        public void Add(Maquinas objMaquina)
        {
            _maquinasRepository.Add(objMaquina);
        }

        public IEnumerable<Maquinas> GetAll(int empCodigo)
        {
            return _maquinasRepository.GetAll(empCodigo);
        }

        public IEnumerable<Maquinas> GetAllAsync()
        {
            return _maquinasRepository.GetAll();

        }

      
        public Maquinas GetById(string id, int empCodigo)
        {
            return _maquinasRepository.GetById(id, empCodigo);
        }

        public Maquinas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            _maquinasRepository.Remove(id);

        }

        public void Remove(string id, int empCodigo)
        {
            _maquinasRepository.Remove(id, empCodigo);
        }

        public void Update(Maquinas objMaquina)
        {
            _maquinasRepository.Update(objMaquina);
        }
    }
}
