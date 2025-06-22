using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _repository;
        public GrupoService(IGrupoRepository rep)
        {
            _repository= rep;
        }
        public void Add(Grupo objGrupo)
        {
            _repository.Add(objGrupo);
        }

        public IEnumerable<Grupo> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Grupo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id); 
        }

        public void Update(Grupo objGrupo)
        {
            _repository.Update(objGrupo);
        }
    }
}
