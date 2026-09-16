using System.ComponentModel.DataAnnotations.Schema;
using Atividade_API.Models.Usuarios;

namespace Atividade_API.Models
{
    public class Boletim
    {
        public int Id { get; set; }
        public float nota { get; set; }

        public int DisciplinaID { get; set; }
        public int AlunoID { get; set; }

        [ForeignKey("DisciplinaID")]
        public Disciplina disciplina { get; set; }

        [ForeignKey("AlunoID")]
        public Aluno aluno { get; set; } 
    }
}
