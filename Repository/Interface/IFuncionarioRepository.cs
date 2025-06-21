using egourmetAPI.Repository.Interface;
using EgourmetAPI.Model;

namespace EgourmetAPI.Repository.Interface
{
    public interface IFuncionarioRepository:IRepositoryBase<Funcionario>
    {
        public IEnumerable<Funcionario> GetAll(int empresa);
        public void Remove(int funcionario, int empresa);
        public Funcionario GetById(int funCodigo, int empresa);


    }
}
