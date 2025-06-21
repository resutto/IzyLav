using egourmetAPI.Repository.Interface;
using Model;

namespace egourmetAPI
{
    public interface IEmpresaRepository : IRepositoryBase<Empresa>
    {
        IEnumerable<Empresa> GetAllEmpresas();
        ResponseMessage Adicionar(Empresa empresa);

    }
}