using EgourmetAPI.Model;
using EgourmetAPI.Repository.Interface;
using IzyLav.Services.Interface;

namespace IzyLav.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository rep) {
            _clienteRepository = rep;
        }
        public void Add(Cliente objCliente)
        {
            _clienteRepository.Add(objCliente);
        }

        public IEnumerable<Cliente> GetAllClientesPorEmpresa(int empCodigo)
        {
            return _clienteRepository.GetAllClientesPorEmpresa(empCodigo);
        }

        public void RemovePorEmpresa(int id, int empCodigo)
        {
            _clienteRepository.RemovePorEmpresa(id, empCodigo);
        }

        public Cliente GetByIdeEmpresa(int id, int empCodigo) {
            return _clienteRepository.GetByIdeEmpresa(id, empCodigo);
        }
        public IEnumerable<Cliente> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Cliente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Cliente objCliente)
        {
            _clienteRepository.Update(objCliente);
        }
    }
}
