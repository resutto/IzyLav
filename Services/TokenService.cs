using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EgourmetAPI.Model;
using IzyLav.Repository.Interface;
using IzyLav.Services.Interface;
using Microsoft.IdentityModel.Tokens;

namespace IzyLav.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioRepository _usuarioRepository;
        public TokenService(IConfiguration config, IUsuarioRepository userrep)
        {
            _config = config;
            _usuarioRepository = userrep;
        }

        public string GenerateToken(Usuario user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"] ?? string.Empty));
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var signinCredentials = new SigningCredentials(secretKey, algorithm:SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[]
                {
                    new Claim(type: ClaimTypes.Name, value: user.usuario),
                    new Claim(type: ClaimTypes.Role, value: user.Grupo),
                    //user.Role

                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: signinCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
