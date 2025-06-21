namespace EgourmetAPI.Model
{
    public class Creditos
    {
        public int Emp_Codigo { get; set; }
        public int IdCredito { get; set; }
        public string IdAno { get; set; }
        public string DataOperacao { get; set; }
        public string HoraOperacao { get; set; }
        public int Idcredito_Anterior { get; set; }
        public string Idano_Anterior { get; set; }
        public float Valor { get; set; }
        public int Condic_Codigo { get; set; }
        public int Cli_Codigo { get; set; }
        public int IdLanc { get; set; }
        public string LogFrame { get; set; }

    }
}
