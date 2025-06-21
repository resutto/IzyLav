namespace EgourmetAPI.Model
{
    public class ContasReceber
    {
        public int Contrec_Codigo { get; set; }
        public int Emp_Codigo { get; set; }
        public int Contrec_Parcela { get; set; }
        public int Anuencia_Cartorio { get; set; }
        public string Contrec_Conta { get; set; }
        public int Condic_Codigo { get; set; }
        public int Port_Codigo { get; set; }
        public int Tpcob_Codigo { get; set; }
        public int Cli_Codigo { get; set; }
        public string Conta_Codigo { get; set; }
        public string Contrec_Documento { get; set; }
        public string Contrec_Descricao { get; set; }
        public DateTime Contrec_Data_Conta { get; set; }
        public DateTime Contrec_Data_Vencimento { get; set; }
        public float Contrec_Valor { get; set; }
        public float Contrec_Desp_Cartorio { get; set; }
        public float Contrec_Desp_Banco { get; set; }
        public float Contrec_Desp_Outras { get; set; }
        public float Contrec_Desconto { get; set; }
        public float Contrec_Juros { get; set; }
        public float Contrec_Multa { get; set; }
        public float Contrec_Total { get; set; }
        public string Contrec_Observacoes { get; set; }
        public string Contrec_Cancelado { get; set; }
        public int Contrec_Numparcelas { get; set; }
        public int Orc_Codigo { get; set; }
        public string Orc_Ano { get; set; }
        public string Contrec_Nossonumero { get; set; }
        public DateTime Contrec_Dtbaixaauto { get; set; }
        public string Contrec_Recibo { get; set; }
        public DateTime Contrec_Quitacao { get; set; }
        public float Contrec_Vlrpago { get; set; }
        public string Contrec_Nf { get; set; }
        public DateTime Dtmovimentacao { get; set; }
        public DateTime Anuencia_Data { get; set; }
        public string Anuencia_Protocolo { get; set; }
        public DateTime Anuencia_Data_Baixa { get; set; }
        public int Contrec_Controle { get; set; }
        public string Contrec_Autorizacao { get; set; }
        public string Avulso { get; set; }
        public DateTime Dt_Lib_Envio_Cob { get; set; }
        public string Usu_Lib_Envio_Cob { get; set; }
        public string Podepagar_Usuario { get; set; }
    }
}