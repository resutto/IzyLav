using egourmetAPI.Model.Enum;

namespace EgourmetAPI.Model
{
    public class Usuario
    {
        public int Emp_Codigo { get; set; }
        public string usuario { get; set; }
        public int Cli_Codigo { get; set; }
        public int Grup_Codigo { get; set; }
        public string Ususenha { get; set; }
        public string Usulogon { get; set; }
        public string Ususenhaweb { get; set; }
        public string Usuarioweb { get; set; }
        public string Ususenharapida { get; set; }
        public string Grupo { get; set; } //Role
    }
}
