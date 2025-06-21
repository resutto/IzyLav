using egourmetAPI.Model.Enum;

namespace egourmetAPI.Model.UserSecurity
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Role Permissao { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
        public string AccessRole { get; set; }
        public int OrganizacaoId { get; set; }

    }
}
