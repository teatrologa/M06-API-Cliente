using Dapper;
using M06_API_Cliente.Core.Interface;
using M06_API_Cliente.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace M06_API_Cliente.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private IConfiguration _configuration;

        public ClienteRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> GetCliente()
        {
            var query = "SELECT * FROM Clientes";
            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.Query<Cliente>(query).ToList();
        }

        public Cliente GetClienteCpf(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";
            //outra forma de usar o dynamic, abstrai-se o cpf = cpf usado no .Add
            var parameters = new DynamicParameters(new { cpf });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return conn.QueryFirstOrDefault<Cliente>(query, parameters);
        }

        public bool GetClienteCpfBool(string cpf)
        {
            var query = "SELECT * FROM Clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters(new { cpf });

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Query<Cliente>(query, parameters).ToList().Count() == 1;
        }

        public bool InsertCliente(Cliente cliente)
        {
            var query = "INSERT INTO Clientes VALUES (@cpf, @nome, @dataNascimento, @idade, @permissao)";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cliente.Cpf);
            parameters.Add("nome", cliente.Nome);
            parameters.Add("dataNascimento", cliente.DataNascimento);
            parameters.Add("idade", cliente.Idade);
            parameters.Add("permissao", cliente.Permissao);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool UpdateCliente(string cpf, Cliente cliente)
        {
            var query = @"UPDATE Clientes SET cpf = @cpf, nome = @nome, dataNascimento = @datanascimento, idade = @idade, permissao = @permissao WHERE cpf = @cpf";
            cliente.Cpf = cpf;
            var parameters = new DynamicParameters(cliente); //Dynamic faz todas as atualizações :)

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }

        public bool DeleteCliente(string cpf)
        {
            var query = "DELETE FROM Clientes WHERE cpf = @cpf";

            var parameters = new DynamicParameters();
            parameters.Add("cpf", cpf);

            using var conn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            return conn.Execute(query, parameters) == 1;
        }
    }
}