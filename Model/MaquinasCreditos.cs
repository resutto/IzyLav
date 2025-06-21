using System.ComponentModel.DataAnnotations;

namespace egourmetAPI.Model
{
    public class MaquinasCreditos
    {
        public int Emp_Codigo { get; set; }
        public int IdLanc { get; set; }
        public string IdMaquina { get; set; }
        public DateTime DataUtilizacao { get; set; }
        public string HoraUtilizacao { get; set; }
        public int IdCredito { get; set; }
        public string IdAno { get; set; }   
        public int Cli_Codigo { get; set; }
    }
}
