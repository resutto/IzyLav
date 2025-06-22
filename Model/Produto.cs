using Microsoft.AspNetCore.Routing.Constraints;
using System.Security.Principal;

namespace EgourmetAPI.Model
{
    public class Produto
    {
        public string Pro_Codigo { get; set; }
        public int Emp_Codigo { get; set; }
        public int For_Codigo { get; set; }
        public int Unid_Codigo { get; set; }
        public int Grup_Codigo { get; set; }
        public int Fam_Codigo { get; set; }
        public DateTime Pro_Data_Cadastro { get; set; }
        public int Fab_Codigo { get; set; }
        public float Pro_Custo { get; set; }
        public float Pro_Preco_Venda { get; set; }
        public DateTime Pro_Ultima_Compra { get; set; }
        public DateTime Pro_Ultima_Venda { get; set; }
        public float Pro_Estoque_Minimo { get; set; }
        public float Pro_Estoque_Atual { get; set; }
        public float Pro_Estoque_Previsto { get; set; }
        public string Pro_Imagem1 { get; set; }
        public string Pro_Localizacao { get; set; }
        public string Pro_Observacao { get; set; }
        public string Pro_Barra { get; set; }
        public string Pro_Baixa_Automatica { get; set; }
        public string Pro_Modelo { get; set; }
        public float Pro_Peso_Unitario { get; set; }
        public float Pro_Altura { get; set; }
        public float Pro_Largura { get; set; }
        public float Pro_Icms { get; set; }
        public string Pro_Sit { get; set; }
        public int Cli_Codigo { get; set; }
        public float Prod_Comissao { get; set; }
        public string Conta_Codigo { get; set; }
        public string Pro_Tipo { get; set; }
        public string Codfornec { get; set; }
        public string Pro_Indice { get; set; }
        public string Desabilitado { get; set; }
        public float Pro_Perc { get; set; }
        public string Mostrar_Materia { get; set; }
        public string Pro_Marca { get; set; }
        public string Pro_Referencia { get; set; }
        public string Pro_Descricao { get; set; }
        public string Descricaob { get; set; }
        public string Descrfiscal { get; set; }
        public string Ncm { get; set; }
        public int Unid_Codigovenda { get; set; }
        public int Cod_Impressora { get; set; }
        public float Pro_Custo_Medio { get; set; }
        public string Cfop_Out { get; set; }
        public string Cst_Out { get; set; }
        public int Regime { get; set; }
        public int Origem_Nfe { get; set; }
        public float Taxaservico { get; set; }
        public string Pro_Cst_Ipi { get; set; }
        public float Pro_Perc_Ipi { get; set; }
        public string Pro_Cst_Pis { get; set; }
        public float Pro_Perc_Pis { get; set; }
        public string Pro_Cst_Cofins { get; set; }
        public float Pro_Perc_Cofins { get; set; }
        public string Itemservico { get; set; }
        public DateTime Pro_Dtvalidade { get; set; }
        public DateTime Dtalter { get; set; }
        public DateTime Dtsinc { get; set; }
    }
}
