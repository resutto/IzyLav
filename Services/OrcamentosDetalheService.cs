using EgourmetAPI.Model;
using EgourmetAPI.Repository;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;
using Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IzyLav.Services
{
    public class OrcamentosDetalheService : IOrcamentosDetalheService
    {
        private readonly IOrcamentosDetalheRepository _orcamentosDetalheRepository;
        public OrcamentosDetalheService(IOrcamentosDetalheRepository orcDetRep)
        {
            _orcamentosDetalheRepository=orcDetRep;
        }

        public void Add(OrcamentosDetalhe objOrcDet)
        {
            _orcamentosDetalheRepository.Add(objOrcDet);
        }

        public IEnumerable<OrcamentosDetalhe> GetAllAsync(int empCodigo, string ano, int orcCodigo)
        {
            return _orcamentosDetalheRepository.GetAll(empCodigo,ano,orcCodigo);
        }

        public IEnumerable<OrcamentosDetalhe> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public OrcamentosDetalhe GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OrcamentosDetalhe GetById(int empresa, int orcamento, int detalhe, string ano)
        {
            return _orcamentosDetalheRepository.GetById(empresa, orcamento, detalhe, ano);
        }


        public void Remove(int empresa, int orcamento, string ano, int detalhe)
        {
            _orcamentosDetalheRepository.Remove(empresa, orcamento, ano, detalhe);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(OrcamentosDetalhe objOrcDet)
        {
            _orcamentosDetalheRepository.Update(objOrcDet);
        }
    }
}
