using egourmetAPI.Service.Interface;
using IzyLav.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace egourmetAPI.Service
{
    public class EmpresaService : IEmpresaService
    {
        private IEmpresaRepository _repository;
        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository; 
        }

        public void Add(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> GetAllAsync()
        {
            return _repository.GetAllEmpresas();
        }

        public Empresa GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(Empresa objEmpresa)
        {
            _repository.Update(objEmpresa);
        }
    }
}