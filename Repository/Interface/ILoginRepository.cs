using EgourmetAPI.Model;
using IzyLav.Data;

namespace IzyLav.Repository.Interface
{
    public interface ILoginRepository
    {
        public void EsqueceuSenha();
        public Usuario Login(string usuario, string senha);
        public IEnumerable<UsuarioAplicacoesDTO> Aplicacoes(string usuario);

    }
}
