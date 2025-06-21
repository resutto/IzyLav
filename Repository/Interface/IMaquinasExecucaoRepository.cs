using egourmetAPI.Model;
using egourmetAPI.Repository.Interface;

namespace egourmetAPI.Repository.Interface
{
    public interface IMaquinasExecucaoRepository:IRepositoryBase<MaquinasExecucao>
    {
        public IEnumerable<MaquinasExecucao> GetAll(int empresa, int idCred, string idAno, int idLanc);
        public MaquinasExecucao GetById(int empresa, int idCred, string idAno, int idLanc, int Sequencial);
        public void Remove(int empresa, int idCred, string idAno, int idLanc, int Sequencial);

    }
}
