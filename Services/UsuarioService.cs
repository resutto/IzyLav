using egourmetAPI.Model;
using EgourmetAPI.Model;
using IzyLav.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class UsuarioService : IUsuarioService
    {   
        private readonly IUsuarioRepository _usuarioService;
        public UsuarioService(IUsuarioRepository usuariorep) {
            _usuarioService = usuariorep;
        }
        public void Add(Usuario objUsuario)
        {
            _usuarioService.Add(objUsuario);
        }

        public IEnumerable<Usuario> GetAllAsync(int emp_Codigo)
        {
            return _usuarioService.GetAll(emp_Codigo);

        }

        public IEnumerable<Usuario> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Usuario GetById(string userId, int emp_Codigo )
        {
            return _usuarioService.GetById(userId, emp_Codigo);
        }

        public Usuario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public void Remove(string userId, int emp_Codigo){
            _usuarioService.Remove(userId, emp_Codigo);
        }

        public void Update(Usuario objUsuario)
        {
            _usuarioService.Add(objUsuario);
        }
    }
}
