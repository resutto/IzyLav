using EgourmetAPI.Model;

namespace IzyLav.Repository.Interface
{
    public interface ILoginRepository
    {
        public void EsqueceuSenha();
        public Usuario Login(string usuario, string senha);
    }
}
