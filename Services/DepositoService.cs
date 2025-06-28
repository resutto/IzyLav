using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class DepositoService : IDepositoService
    {
        private readonly IDepositoRepository _repository;
        public DepositoService(IDepositoRepository repository) { 
            _repository = repository;
        }
        public void Add(Deposito objDep)
        {
            _repository.Add(objDep);
        }

        public IEnumerable<Deposito> GetAllAsync(int empresa)
        {
            return _repository.GetAll(empresa);
        }

        public IEnumerable<Deposito> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Deposito GetById(int id, int empresa)
        {
            return _repository.GetById(id, empresa);
        }

        public Deposito GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, int empresa)
        {
            _repository.Remove(id, empresa);    
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Deposito objDep)
        {
            _repository.Update(objDep);
        }
    }
}
