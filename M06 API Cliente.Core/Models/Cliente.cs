using System.ComponentModel.DataAnnotations;

namespace M06_API_Cliente.Core.Models
{
    public class Cliente
    {
        public long Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public string Permissao { get; set; }
    }
}