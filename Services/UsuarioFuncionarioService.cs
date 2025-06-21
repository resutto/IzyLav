using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class UsuarioFuncionarioService : IUsuarioFuncionarioService
    {
        private readonly IUsuarioFuncionarioRepository _usuarioFuncionarioRepository;

        public UsuarioFuncionarioService(IUsuarioFuncionarioRepository rep)
        {
            _usuarioFuncionarioRepository = rep;
        }
        public void Add(UsuarioFuncionario objUsuFunc)
        {
            _usuarioFuncionarioRepository.Add(objUsuFunc);
        }

        public IEnumerable<UsuarioFuncionario> GetAll(int empresa, string usuario) { 
            return _usuarioFuncionarioRepository.GetAll(empresa, usuario);
        }

        public IEnumerable<UsuarioFuncionario> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public UsuarioFuncionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioFuncionario objUsuFunc)
        {
            _usuarioFuncionarioRepository.Update(objUsuFunc);
        }
    }
}
