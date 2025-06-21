using System.Globalization;

namespace egourmetAPI.Model
{
    public class MaquinasExecucao
    {
        public int emp_Codigo { get; set; }
        public int idCredito { get; set; }
        public string idAno { get; set; }
        public int idLanc { get; set; }
        public int sequencial { get; set; }
        public string idMaquina { get; set; }
        public int idEtapa { get; set; }
        public DateTime dtInicioExecucao { get; set; }
        public DateTime dtFinalExecucao { get; set; }
        public string status { get; set; }
    }
}
