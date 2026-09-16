using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Atividade_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurmaID = table.Column<int>(type: "int", nullable: false),
                    ProfessorID = table.Column<int>(type: "int", nullable: false),
                    DisciplinaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nota = table.Column<float>(type: "real", nullable: false),
                    DisciplinaID = table.Column<int>(type: "int", nullable: false),
                    AlunoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeDisciplina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplinaTurma",
                columns: table => new
                {
                    DisciplinasId = table.Column<int>(type: "int", nullable: false),
                    TurmasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaTurma", x => new { x.DisciplinasId, x.TurmasId });
                    table.ForeignKey(
                        name: "FK_DisciplinaTurma_Disciplina_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idade = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hashSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matricula = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: true),
                    TurmaId1 = table.Column<int>(type: "int", nullable: true),
                    formacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeTurma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    anoLetivo = table.Column<int>(type: "int", nullable: false),
                    turno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Pessoa_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_DisciplinaID",
                table: "Atividade",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_ProfessorID",
                table: "Atividade",
                column: "ProfessorID");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_TurmaID",
                table: "Atividade",
                column: "TurmaID");

            migrationBuilder.CreateIndex(
                name: "IX_Boletim_AlunoID",
                table: "Boletim",
                column: "AlunoID");

            migrationBuilder.CreateIndex(
                name: "IX_Boletim_DisciplinaID",
                table: "Boletim",
                column: "DisciplinaID");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaTurma_TurmasId",
                table: "DisciplinaTurma",
                column: "TurmasId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TurmaId",
                table: "Pessoa",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_TurmaId1",
                table: "Pessoa",
                column: "TurmaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_ProfessorId",
                table: "Turma",
                column: "ProfessorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Disciplina_DisciplinaID",
                table: "Atividade",
                column: "DisciplinaID",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Pessoa_ProfessorID",
                table: "Atividade",
                column: "ProfessorID",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atividade_Turma_TurmaID",
                table: "Atividade",
                column: "TurmaID",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletim_Disciplina_DisciplinaID",
                table: "Boletim",
                column: "DisciplinaID",
                principalTable: "Disciplina",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletim_Pessoa_AlunoID",
                table: "Boletim",
                column: "AlunoID",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplina_Pessoa_ProfessorId",
                table: "Disciplina",
                column: "ProfessorId",
                principalTable: "Pessoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DisciplinaTurma_Turma_TurmasId",
                table: "DisciplinaTurma",
                column: "TurmasId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Turma_TurmaId",
                table: "Pessoa",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Turma_TurmaId1",
                table: "Pessoa",
                column: "TurmaId1",
                principalTable: "Turma",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Pessoa_ProfessorId",
                table: "Turma");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Boletim");

            migrationBuilder.DropTable(
                name: "DisciplinaTurma");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
