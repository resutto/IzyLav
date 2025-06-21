using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface ICreditosService: IServiceBase<Creditos>
    {
        public IEnumerable<Creditos> GetAllAsync1(int empCodigo);
        public IEnumerable<Creditos> GetTicketsCompradosLivres(int empCodigo);
        public Creditos GetById(int id, int empCodigo, string ano);
        public void ConsumirCreditoMaquina(int empCodigo, int idCredito, string idAno, string idMaquina);
    }
}
