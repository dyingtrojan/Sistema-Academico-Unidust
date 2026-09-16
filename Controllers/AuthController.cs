using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Atividade_API.Data;
using Atividade_API.Models;
using Atividade_API.Models.Usuarios;

namespace Atividade_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var pessoa = await _context.Pessoa
                .FirstOrDefaultAsync(p => p.email == dto.email);

            if (pessoa == null || pessoa.hashSenha != dto.senha)
            {
                return Unauthorized(new { mensagem = "E-mail ou senha inválidos." });
            }

            string role = pessoa switch
            {
                Administrador => "Admininistrador",
                Professor => "Professor",
                Aluno => "Aluno",
                _ => "Usuario"
            };

            return Ok(new
            {
                mensagem = "Login realizado com sucesso!",
                role = role,
                usuario = new { pessoa.Id, pessoa.nome, pessoa.email }
            });
        }
    }
}