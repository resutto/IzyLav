using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IFamiliaRepository: IRepositoryBase<Familia>
    {
        public Familia GetByIdGrupoFamilia(int idFamilia, int idGrupo);
        public void RemoveIdGrupoFamilia(int idFamilia, int idGrupo);
        public IEnumerable<Familia> GetAll(int grupCodigo);


    }

}
