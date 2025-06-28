using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class CfopService : ICfopService
    {
        private readonly ICfopRepository _repositorio;
        public CfopService(ICfopRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Add(Cfop objCfop)
        {
            _repositorio.Add(objCfop);
        }

        public IEnumerable<Cfop> GetAllAsync()
        {
            return _repositorio.GetAll();
        }

        public Cfop GetById(string id)
        {
            return _repositorio.GetById(id);
        }

        public Cfop GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(string id)
        {
            _repositorio.Remove(id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cfop obj)
        {
            throw new NotImplementedException();
        }
    }
}
