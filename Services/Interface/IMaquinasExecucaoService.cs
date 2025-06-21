using egourmetAPI.Model;
using egourmetAPI.Service.Interface;

namespace IzyLav.Services.Interface
{
    public interface IMaquinasExecucaoService:IServiceBase<MaquinasExecucao>
    {
        public IEnumerable<MaquinasExecucao> GetAllAsync(int empresa, int idCred, string idAno, int idLanc);
        public void Remove(int empresa, int idCred, string idAno, int idLanc, int Sequencial);
        public MaquinasExecucao GetById(int empresa, int idCred, string idAno, int idLanc, int Sequencial);
    }
}
