using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class FormaPagtoService : IFormaPagtoService
    {
        private readonly IFormaPagtoRepository _repository;

        public FormaPagtoService(IFormaPagtoRepository repository)
        {
            _repository = repository;
        }

        public void Add(FormaPagto objForma)
        {
            _repository.Add(objForma);
        }

        public IEnumerable<FormaPagto> GetAllAsync(string tipo)
        {
            return _repository.GetAll(tipo);
        }

        public IEnumerable<FormaPagto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public FormaPagto GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(FormaPagto objForma)
        {
            _repository.Update(objForma);
        }
    }
}
