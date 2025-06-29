using EgourmetAPI.Model;
using IzyLav.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public void EsqueceuSenha()
        {
            _loginRepository.EsqueceuSenha();
        }

        public Usuario Login(string usuario, string senha)
        {
            return _loginRepository.Login(usuario, senha);
        }
    }
}
