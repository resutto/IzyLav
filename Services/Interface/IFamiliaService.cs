using egourmetAPI.Service.Interface;
using EgourmetAPI.Model;

namespace IzyLav.Services.Interface
{
    public interface IFamiliaService:IServiceBase<Familia>
    {
        public IEnumerable<Familia> GetAll(int grupCodigo);
        public Familia GetById(int idFamilia, int idGrupo);
        public void Remove(int idFamilia, int idGrupo);

    }
}
