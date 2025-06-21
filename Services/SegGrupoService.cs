using EgourmetAPI.Helpers;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class SegGrupoService : ISegGrupoService
    {
        private readonly ISegGrupoRepository _rep;
        public SegGrupoService(ISegGrupoRepository rep) {
            _rep = rep;
        }    
        public void Add(SegGrupo objSeg)
        {
            _rep.Add(objSeg);
        }

        public IEnumerable<SegGrupo> GetAllAsync()
        {
            return _rep.GetAll();
        }

        public SegGrupo GetById(int id)
        {
            return _rep.GetById(id);
        }

        public void Remove(int id)
        {
            _rep.Remove(id);
        }

        public void Update(SegGrupo objSeg)
        {
            _rep.Update(objSeg);
        }
    }
}
