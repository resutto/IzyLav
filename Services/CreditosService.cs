using egourmetAPI.Repository;
using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class CreditosService : ICreditosService
    {   
        private ICreditosRepository _creditosRepository;
        public CreditosService(ICreditosRepository creditos) {
            _creditosRepository = creditos;
        }
        public void Add(Creditos objCreditos)
        {
            _creditosRepository.Add(objCreditos);
        }

        public IEnumerable<Creditos> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Creditos> GetAllAsync1(int empCodigo)
        {
            return _creditosRepository.GetAll(empCodigo);
        }

        public Creditos GetById(int id)
        {
            return _creditosRepository.GetById(id);
        }
        public void Remove(int id)
        {
            _creditosRepository.Remove(id); 
        }

        public void Update(Creditos objCredito)
        {
            _creditosRepository.Update(objCredito);    
        }

        public IEnumerable<Creditos> GetTicketsCompradosLivres(int empCodigo)
        {
            return _creditosRepository.GetTicketsCompradosLivres(empCodigo);
        }

        public Creditos GetById(int id, int empCodigo, string ano){
            return _creditosRepository.GetById(id,empCodigo,ano);
        }

        public void ConsumirCreditoMaquina(int empCodigo, int idCredito, string idAno, string idMaquina){
            _creditosRepository.ConsumirCreditoMaquina(empCodigo,idCredito,idAno,idMaquina);
        }
    }
}
