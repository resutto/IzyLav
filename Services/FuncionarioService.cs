using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repositorio;
        public FuncionarioService(IFuncionarioRepository  rep) {
            _repositorio = rep;
        }
        public void Add(Funcionario objFuncionario)
        {
            _repositorio.Add(objFuncionario);
        }

        public IEnumerable<Funcionario> GetAllAsync(int empresa)
        {
            return _repositorio.GetAll(empresa);
        }

        public IEnumerable<Funcionario> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Funcionario GetById(int funCodigo, int empresa)
        {
            return _repositorio.GetById(funCodigo, empresa);
        }
        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id, int empresa)
        {
            _repositorio.Remove(id, empresa);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Funcionario objFuncionario)
        {
            _repositorio.Update(objFuncionario);
        }
    }
}
