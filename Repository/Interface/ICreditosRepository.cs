
using EgourmetAPI.Model;

namespace egourmetAPI.Repository.Interface
{
    public interface ICreditosRepository:IRepositoryBase<Creditos>
    {
        public IEnumerable<Creditos> GetAll(int empCodigo);
        public Creditos GetById(int id, int empCodigo, string ano);
        public IEnumerable<Creditos> GetTicketsCompradosLivres(int empCodigo);
        public void ConsumirCreditoMaquina(int empCodigo, int idCredito, string idAno, string idMaquina);
    }
}
