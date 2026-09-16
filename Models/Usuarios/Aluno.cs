using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace Atividade_API.Models.Usuarios
{
    public class Aluno : Pessoa
    {
        public int matricula { get; set; }
        public string status { get; set; }

        public int? TurmaId { get; set; }
        [ForeignKey("TurmaId")]
        [ValidateNever]
        public Turma? turma { get; set; }
    }
}
