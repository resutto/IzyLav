using egourmetAPI.Model.Enum;

namespace egourmetAPI.Model.UserSecurity
{
    public class AuthenticatePost
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Role Permissao { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
