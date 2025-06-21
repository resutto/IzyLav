namespace EgourmetAPI.Model
{
    public class Fornecedor
    {
        public int For_Codigo { get; set; }
        public string For_Nome_Fantasia { get; set; }
        public string For_Razao_Social { get; set; }
        public string For_Cep { get; set; }
        public string For_Endereco { get; set; }
        public string For_Bairro { get; set; }
        public string For_Numero { get; set; }
        public string For_Cidade { get; set; }
        public string For_Uf { get; set; }
        public string For_Compl { get; set; }
        public string For_Telefone { get; set; }
        public string For_Email { get; set; }
        public string For_Home_Page { get; set; }
        public string For_CpfCnpj { get; set; }
        public string For_Inscricao_Estadual { get; set; }
        public string For_Inscricao_Municipal { get; set; }
        public string For_Observacao { get; set; }
        public string For_Anotacao { get; set; }
        public string Ativo { get; set; }
        public DateTime For_Data_Cadastro { get; set; }
    }
}
