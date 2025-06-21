namespace EgourmetAPI.Model
{
    public class ContasPagar
    {
        public int Contpag_Codigo{ get; set; }
        public int Emp_Codigo { get; set; }
        public int Contpag_Parcela { get; set; }
        public int For_Codigo { get; set; }
        public int Cpsgrup_Codigo{ get; set; }
        public int Cpgrup_Codigo { get; set; }
        public string Contpag_Conta { get; set; }
        public int Condic_Codigo { get; set; }
        public string Contpag_Documento { get; set; }
        public string Contpag_Descricao { get; set; }
        public DateTime Contpag_Data_Conta { get; set; }
        public DateTime Contpag_Data_Vencimento { get; set; }
        public float Contpag_Valor{ get; set; }
        public float Contpag_Desconto { get; set; }
        public float Contpag_Juros { get; set; }
        public float Contpag_Multa { get; set; }
        public float Contpag_Total { get; set; }
        public string Contpag_Observacoes { get; set; }
        public string Contpag_Cancelado { get; set; }
        public int Contpag_Numparcelas { get; set; }
        public int Ped_Codigo { get; set; }
        public DateTime Contpag_Quitacao{ get; set; }
        public float Contpag_Vlrpago { get; set; }
        public string Contpag_Nf { get; set; }
        public float Contpag_Troco{ get; set; }
        public string Snrocheque { get; set; }
        public string Despfixa { get; set; }
        public string despesa_fixa { get; set; }
        public string cheque { get; set; }
        public string PodePagar_Usuario { get; set; }
        public string Tem_Boleto { get; set; }
        public string Tem_Nota { get; set; }
        public int Preped_Codigo{ get; set; }
        public int Cartorio{ get; set; }
        public float Valor { get; set; }
        public DateTime Entrada{ get; set; }
        public DateTime Vencto{ get; set; }
        public string Protocolo { get; set; }
  }
}
