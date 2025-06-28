using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class FamiliaService : IFamiliaService
    {
        private readonly IFamiliaRepository _repository;

        public FamiliaService(IFamiliaRepository repository) { 
            _repository = repository;
        }
        public void Add(Familia objFamilia)
        {
            _repository.Add(objFamilia);
        }

        public IEnumerable<Familia> GetAll(int grupCodigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Familia> GetAllAsync(int grupo)
        {
            return _repository.GetAll(grupo);
        }

        public IEnumerable<Familia> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Familia GetById(int idFamilia, int idGrupo)
        {
            return _repository.GetByIdGrupoFamilia(idFamilia, idGrupo);
        }

        public Familia GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int idFamilia, int idGrupo)
        {
            _repository.RemoveIdGrupoFamilia(idFamilia, idGrupo);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Familia objFamilia)
        {
            _repository.Update(objFamilia);
        }
    }
}
