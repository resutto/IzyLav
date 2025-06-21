namespace EgourmetAPI.Model
{
    public class CaixaSaldos
    {
        public int Emp_Codigo { get; set; }
        public int Sald_Codigo { get; set; }
        public string Conta_Codigo { get; set; }
        public DateTime Data { get; set; }
        public float Saldo_Anterior { get; set; }
        public float Saldo_Dia { get; set; }
        public float Saldo_Atual { get; set; }
        public string Obs { get; set; }
        public string Ultimo { get; set; }
        public string Sit { get; set; }
        public string Tipo { get; set; }
        public string Usuario { get; set; }
        public string Hora { get; set; }
        public string Pc_Abriucx { get; set; }
    }
}
