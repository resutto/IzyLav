using EgourmetAPI.Model;
using IzyLav.Data;
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

        public IEnumerable<UsuarioAplicacoesDTO> Aplicacoes(string usuario, int empresa){
            return _loginRepository.Aplicacoes(usuario,empresa);
        }

    }
}
