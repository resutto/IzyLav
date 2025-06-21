using System.Globalization;

namespace egourmetAPI.Model
{
    public class Maquinas
    {
        public int Emp_Codigo { get; set; }
        public string IdMaquina { get; set; }
        public string NomeMaquina { get; set; }
        public int TipoMaquina { get; set; }
        public string FuncaoLavar { get; set; }
        public string FuncaoSecar { get; set; }
        public string Trabalhando { get; set; }
        public string Bloqueada { get; set; }

    }
}
