using Microsoft.EntityFrameworkCore;

namespace Atividade_API.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public int idade { get; set; }
        public string email { get; set; }
        public string hashSenha { get; set; }
        public string tipoPessoa { get; set; }
    }
}
