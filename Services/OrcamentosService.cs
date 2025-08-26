using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class OrcamentosService : IOrcamentosService
    {
        private readonly IOrcamentosRepository _rep;
        public OrcamentosService(IOrcamentosRepository repositorio) {
            _rep = repositorio;
        }
        public String Add(Orcamentos objOrcamento)
        {
            return _rep.Add(objOrcamento);
        }

        public IEnumerable<Orcamentos> GetAllAsync(int empresa)
        {
            return _rep.GetAll(empresa);
        }

        public IEnumerable<Orcamentos> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Orcamentos GetById(int empresa, int orcamentoid, string ano)
        {
            return _rep.GetById(empresa, orcamentoid, ano);
        }

        public Orcamentos GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int emp_Codigo, int orc_Codigo, string ano)
        {
            _rep.Remove(emp_Codigo, orc_Codigo, ano);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Orcamentos objOrcamento)
        {
            _rep.Update(objOrcamento);
        }

        void IServiceBase<Orcamentos>.Add(Orcamentos obj)
        {
            throw new NotImplementedException();
        }
    }
}
