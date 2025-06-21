using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class SetorService : ISetorService
    {
        private readonly ISetorRepository _rep;
        public SetorService(ISetorRepository rep) {
            _rep = rep;
        }
        public void Add(Setor objSetor)
        {
            _rep.Add(objSetor);
        }

        public IEnumerable<Setor> GetAllAsync()
        {
            return _rep.GetAll();
        }

        public Setor GetById(int id)
        {
            return _rep.GetById(id);
        }

        public void Remove(int id)
        {
            _rep.Remove(id);
        }

        public void Update(Setor objSetor)
        {
            _rep.Update(objSetor);
        }
    }
}
