using egourmetAPI.Model.Enum;
using System;
using System.Text.Json.Serialization;

namespace egourmetAPI.Model
{
    public class User
    {
        public int Id { get; set; }
        public int? OrganizacaoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Role Permissao { get; set; }
        public string Login { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }

    public class UserImporterAuth
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int OrganizacaoId { get; set; }
        public int? Grup_Codigo { get; set; }
        public Role Permissao { get; set; }
       
        [JsonIgnore]
        public string Ususenha { get; set; }
    }
}
