using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_API_Cliente.Core.Service
{
    public class ClienteService : IClienteService
    {
        public IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public List<Cliente> GetCliente()
        {
            return _clienteRepository.GetCliente();
        }

        public Cliente GetClienteCpf(string cpf)
        {
            return _clienteRepository.GetClienteCpf(cpf);
        }

        public bool InsertCliente(Cliente cliente)
        {
            return _clienteRepository.InsertCliente(cliente);
        }

        public bool UpdateCliente(string cpf, Cliente cliente)
        {
            return _clienteRepository.UpdateCliente(cpf, cliente);
        }

        public bool DeleteCliente(string cpf)
        {
            return _clienteRepository.DeleteCliente(cpf);
        }
    }
}
