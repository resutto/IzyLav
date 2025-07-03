using System.ComponentModel.DataAnnotations;

namespace IzyLav.Data
{
    public class UsuarioAplicacoesDTO
    {
        public string Grupo_Descricao { get; set; }
        
        public string Apli_Codigo { get; set; }
        public string Apli_Descricao { get; set; }
        public string Apli_Tipo { get; set; }
        public string Apli_Descricao_Curta { get; set; }

        /*[MaxLength(10)]*/
        [StringLength(10)]
        public string Usuario { get; set; }

    }
}
