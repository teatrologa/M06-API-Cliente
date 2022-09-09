using M06_API_Cliente.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_API_Cliente.Core.Interface
{
    public interface IClienteService
    {
        public List<Cliente> GetCliente();

        public Cliente GetClienteCpf(string cpf);

        public bool InsertCliente(Cliente cliente);

        public bool UpdateCliente(string cpf, Cliente cliente);

        public bool DeleteCliente(string cpf);
    }
}
