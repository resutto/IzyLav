using System.ComponentModel.DataAnnotations;

namespace egourmetAPI.Model.UserSecurity
{
    public class AuthenticateRequest
    {
        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        public int? OrganizationId { get; set; }
    }
}
