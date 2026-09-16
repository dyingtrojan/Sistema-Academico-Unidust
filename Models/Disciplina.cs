namespace Atividade_API.Models
{
    public class Disciplina
    {
        public string Id { get; set; }
        public string nomeDisciplina { get; set; }
        public int CargaHoraria { get; set; }
        public int Id { get; set; }
        public string? nomeDisciplina { get; set; }
        public int? CargaHoraria { get; set; }

        public ICollection<Turma>? Turmas { get; set; } = new List<Turma>();
    }
}
