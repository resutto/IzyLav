using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class UfService : IUfService
    {
        private readonly IUfRepository _repository;
        
        public UfService(IUfRepository rep)
        {
            _repository = rep;
        }
        public void Add(Uf objUf)
        {
            _repository.Add(objUf);
        }

        public IEnumerable<Uf> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Uf GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Uf GetById(string id)
        {
            return _repository.GetByUf(id);
        }


        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            _repository.RemoveUf(id);
        }

        public void Update(Uf objUf)
        {
            _repository.Update(objUf);
        }
    }
}
