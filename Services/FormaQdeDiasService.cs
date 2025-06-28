using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class FormaQdeDiasService : IFormaQdeDiasService
    {
        private readonly IFormaQdeDiasRepository _repository;
        public FormaQdeDiasService(IFormaQdeDiasRepository repository)
        {
            _repository = repository;
        }

        public void Add(FormaQdeDias objFormaQdeDias)
        {
            _repository.Add(objFormaQdeDias);
        }

        public IEnumerable<FormaQdeDias> GetAllAsync(int forma)
        {
            return _repository.GetAll(forma);
        }

        public IEnumerable<FormaQdeDias> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public FormaQdeDias GetById(int id, int forma)
        {
            return _repository.GetById(id, forma);
        }

        public FormaQdeDias GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, int forma)
        {
            _repository.Remove(id, forma);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(FormaQdeDias objFormaQdeDias)
        {
            _repository.Update(objFormaQdeDias);
        }
    }
}
