namespace Atividade_API.Models.Usuarios
{
    public class Professor : Pessoa
    {
        public string? formacoes { get; set; }
        public string? cargo { get; set; }

        public ICollection<Turma> Turmas { get; set; } = new List<Turma>();
        public ICollection<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
    }
}
