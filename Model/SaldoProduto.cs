namespace EgourmetAPI.Model
{
    public class SaldoProduto
    {
        public int Emp_Codigo { get; set; }
        public int Dep_Codigo { get; set; }
        public string Pro_Codigo { get; set; }
        public float Saldo_Anterior { get; set; }
        public float Saldo_Atual { get; set; }
        public float Pro_Custo_Medio { get; set; }
    }
}
