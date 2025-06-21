using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class UsuarioAplicService : IUsuarioAplicService
    {
        private readonly IUsuarioAplicRepository _repositorio;
        public UsuarioAplicService(IUsuarioAplicRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public void Add(Usuaplic objUsuAplic)
        {
            _repositorio.Add(objUsuAplic);
        }

        public IEnumerable<Usuaplic> GetAllAsync(int Grupo)
        {
            return _repositorio.GetAll(Grupo);
        }

        public IEnumerable<Usuaplic> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Usuaplic GetById(int Grupo, string Aplicacao)
        {
            return _repositorio.GetById(Grupo, Aplicacao);
        }

        public Usuaplic GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int Grupo, string Aplicacao)
        {
            _repositorio.Remove(Grupo, Aplicacao);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuaplic objUsuAplic)
        {
            throw new NotImplementedException();
        }
    }
}
