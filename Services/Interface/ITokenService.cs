using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ITokenService
    {
        public string GenerateToken(Usuario user);
    }
}
