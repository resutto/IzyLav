using egourmetAPI.Model;
using IzyLav.Model;

namespace egourmetAPI.Repository.Interface
{
    public interface IMaquinasRepository:IRepositoryBase<Maquinas>
    {
        void Add(MaquinasEtapas objMaquinasEtapas);
        public IEnumerable<Maquinas> GetAll(int empCodigo);
        public Maquinas GetById(string id, int empCodigo);
        public void Remove(string id, int empCodigo);

    }
}
