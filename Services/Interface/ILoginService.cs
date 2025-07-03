using EgourmetAPI.Model;
using IzyLav.Data;

namespace IzyLav.Services.Interface
{
    public interface ILoginService
    {
        public void EsqueceuSenha();
        public Usuario Login(string usuario, string senha);
        public IEnumerable<UsuarioAplicacoesDTO> Aplicacoes(string usuario);
    }
}
