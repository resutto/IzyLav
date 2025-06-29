using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ILoginService
    {
        public void EsqueceuSenha();
        public Usuario Login(string usuario, string senha);

    }
}
