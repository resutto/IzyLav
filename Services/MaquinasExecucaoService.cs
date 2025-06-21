using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class MaquinasExecucaoService : IMaquinasExecucaoService
    {
        private readonly IMaquinasExecucaoRepository  _repository;

        public MaquinasExecucaoService(IMaquinasExecucaoRepository rep) {
        
            _repository = rep;
        }
        public void Add(MaquinasExecucao objMaquinaExecucao)
        {
            _repository.Add(objMaquinaExecucao);
        }

        public IEnumerable<MaquinasExecucao> GetAllAsync(int empresa, int idCred, string idAno, int idLanc)
        {
            return _repository.GetAll(empresa, idCred, idAno, idLanc);
        }

        public IEnumerable<MaquinasExecucao> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public MaquinasExecucao GetById(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            return _repository.GetById(empresa, idCred, idAno, idLanc, Sequencial);
        }

        public MaquinasExecucao GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int empresa, int idCred, string idAno, int idLanc, int Sequencial)
        {
            _repository.Remove(empresa, idCred, idAno, idLanc, Sequencial);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(MaquinasExecucao objMaquinaExecucao)
        {
            _repository.Update(objMaquinaExecucao);
        }
    }
}
