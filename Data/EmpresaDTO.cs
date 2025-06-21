using System.ComponentModel.DataAnnotations;

namespace IzyLav.Data
{
    public class EmpresaDTO
    {
        [Required] 
        public int Emp_Codigo { get; set; }
        [Required] 
        [StringLength(50)]
        public string Emp_Nome_Fantasia { get; set; }
        [Required]
        [StringLength(50)] 
        public string Emp_Razao_Social { get; set; }
        public string Emp_Cgc { get; set; }
        public string Emp_inscricao_Estadual { get; set; }
        [Required]
        public string Emp_Endereco { get; set; }
        [Required] public string Emp_Bairro { get; set; }

        [Required]public string Emp_Cidade { get; set; }
        public string Emp_Uf { get; set; }
        public string Emp_Cep { get; set; }
        public string Emp_Telefone { get; set; }
        public string Emp_Email { get; set; }
        public string Emp_numero { get; set; }
        public string Emp_Complemento { get; set; }
        public string Emp_Www { get; set; }
        public string Emp_Logotipo { get; set; }
        public string Emp_Inscricao_Municipal { get; set; }
        public string Cfop_Codigo { get; set; }
        public string Cnaefiscal { get; set; }
        public int Regime { get; set; }
        public string Inscricao_Suframa { get; set; }

    }
}
