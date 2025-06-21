namespace EgourmetAPI.Model
{
    public class Cliente
    {
        public int Emp_Codigo { get; set; }
        public int Cli_Codigo { get; set; }
        public string Cli_Nome { get; set; }
        public string Cli_Razao_Social { get; set; }
        public DateTime Cli_Data_Cadastro { get; set; }
        public string Cli_responsavel { get; set; }
        public string Cli_Sexo { get; set; }
        public DateTime Cli_Data_Nascimento { get; set; }
        public string Cli_CpfCnpj { get; set; }
        public string Cli_Tipopessoa { get; set; }
        public string IndicadorIEDestinatario { get; set; }
        public string Cli_Cep { get; set; }
        public string Cli_Endereco { get; set; }
        public string Cli_Numero { get; set; }
        public string Cli_Bairro { get; set; }        
        public string Cli_Cidade { get; set; }       
        public string Cli_Uf { get; set; }
        public string Cli_Referencia { get; set; }
        public string Cli_Compl { get; set; }        
        public string Cli_Telefone { get; set; }
        public string Cli_Telefone2 { get; set; }
        public string Cli_Telefone3 { get; set; }
        public string Cli_Home_Page { get; set; }
        public string Cli_Email { get; set; }
        public string Cli_Email_Xml { get; set; }
        public string Cli_Observacoes { get; set; }
        public string Cli_Anotacoes { get; set; }
        public string Cli_Inscricao_Estadual { get; set; }
        public string Cli_Inscricao_Municipal { get; set; }
        public string Cli_Inscricao_Suframa { get; set; }
        public string Fantasiasem { get; set; }
        public string Razsocsem { get; set; }
        public string Desabilitado { get; set; }
        
    }
}
