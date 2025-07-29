using Microsoft.AspNetCore.Routing.Constraints;
using System.Security.Principal;

namespace EgourmetAPI.Model
{
    public class ProdutoShowRoom
    {
        public string Pro_Codigo { get; set; }
        public int Emp_Codigo { get; set; }
        public int Unid_Codigo { get; set; }
        public int Grup_Codigo { get; set; }
        public float Pro_Preco_Venda { get; set; }
        public string Pro_Imagem1 { get; set; }
        public string Pro_Barra { get; set; }
        public string Pro_Descricao { get; set; }
    }
}
