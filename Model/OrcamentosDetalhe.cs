namespace EgourmetAPI.Model
{
    public class OrcamentosDetalhe
    {
        public int Emp_Codigo { get; set; }
        public int Orc_Codigo { get; set; }
        public int Detorc_Codigo { get; set; }
        public int Cli_Codigo { get; set; }
        public string ORC_Ano { get; set; }
        public int Unid_Codigo { get; set; }
        public string Pro_Codigo { get; set; }
        public float Detorc_Qtde { get; set; }
        public float Detorc_Custotot { get; set; }
        public float Detorc_Custo { get; set; }
        public string Detorc_Observacao { get; set; }
        public DateTime Data_Impressao { get; set; }
        public string Infadicional { get; set; }
        public DateTime Data_Pedido_Web { get; set; }
        public DateTime Data_Cofirmacao_Web { get; set; }
        public int Fun_Codigo { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public int Seqproducao { get; set; }
        public string Mercadoria_Produzida { get; set; }
        public string Usuario_Producao { get; set; }
        public string Mercadoria_Entregue { get; set; }
        public string Usuario_Entrega { get; set; }
        public float Totaproxtributoitem { get; set; }
        public int Dep_Codigo { get; set; }
        public string Impressaoavulsa { get; set; }
        public string Cst_Icms { get; set; }
        public float Perc_Icms { get; set; }
        public string Cst_Ipi { get; set; }
        public float Perc_Ipi { get; set; }
        public string Cst_Pis { get; set; }
        public float Perc_Pis { get; set; }
        public string Cst_Cofins { get; set; }
        public float Perc_Cofins { get; set; }
        public string Hora_Confirmacao_Web { get; set; }
        public float Detorc_Desconto { get; set; }
        public int Via { get; set; }
        public string Pc_Criou { get; set; }
        public int Qdecasas { get; set; }
        public DateTime Data_Impressao_Avulso { get; set; }
        public int Idmotivodeson { get; set; }
        public float Vicmsdeson { get; set; }
    }
}
