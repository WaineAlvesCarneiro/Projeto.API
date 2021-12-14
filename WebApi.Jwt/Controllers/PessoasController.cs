using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Jwt.Data;
using WebApi.Jwt.Models;
using WebApi.Jwt.Repositories;
using WebApi.Jwt.Services;

namespace WebApi.Jwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        // POST: 1. Uma rota para autenticação;
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(
           [FromBody] User model)
        {
            var _user = UserRepository.Get(model.Username, model.Password);

            if (_user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var _token = TokenService.GenerateToken(_user);
            _user.Password = "";
            return new
            {
                user = _user,
                token = _token
            };
        }

        // GET: 2. Uma rota para consulta de pessoas, que deve retornar uma lista de objeto de pessoas;
        [HttpGet]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<ActionResult<IEnumerable<Pessoas>>> GetPessoas(
            [FromServices] DataContext _context)
        {
            return await _context.Pessoas.ToListAsync();
        }

        // GET: 3. Uma rota para consultar uma pessoa pelo seu código;
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<ActionResult<Pessoas>> GetPessoas(
            [FromServices] DataContext _context, int id)
        {
            var pessoas = await _context.Pessoas.FindAsync(id);

            if (pessoas == null)
            {
                return NotFound("Pessoa não foi encontrada");
            }

            return pessoas;
        }

        // GET: 4. Uma rota para consultar pessoas de uma determinada UF; 
        [HttpGet("{uf}")]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<ActionResult<List<Pessoas>>> GetPessoas(
            [FromServices] DataContext _context, string uf)
        {
            var pessoas = await _context.Pessoas
                .Where(x => x.Uf == uf)
                .ToListAsync();

            if (pessoas == null)
            {
                return NotFound("Pessoa sem dados para exibir");
            }

            return pessoas;
        }

        // POST: 5. Uma rota de gravar pessoa, que deve retornar o objeto “salvo”;
        //a.O método deve ser capaz de validar as informações recebidas;
        [HttpPost]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<ActionResult<Pessoas>> PostPessoas(
            [FromServices] DataContext _context,
            [FromBody] Pessoas pessoas)
        {
            _context.Pessoas.Add(pessoas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPessoas", new { id = pessoas.Id }, pessoas);
        }

        // PUT: 6. Uma rota para atualizar os dados de uma pessoa, que deve retorno o objeto atualizado;
        [HttpPut("{id}")]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<IActionResult> PutPessoas(
            [FromServices] DataContext _context, int id,
            [FromBody] Pessoas pessoas)
        {
            if (id != pessoas.Id)
            {
                return BadRequest("Pessoa não foi encontrada para editar");
            }

            _context.Entry(pessoas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pessoas.Any(e => e.Id == id))
                {
                    return NotFound("Nenhuma pessoa encotrada com esse ID");
                }
                else
                {
                    throw;
                }
            }

            return Ok(pessoas);
        }

        // DELETE: 7. Uma rota para excluir uma pessoa.
        [HttpDelete("{id}")]
        [Authorize(Roles = "Basico,Admin")]
        public async Task<IActionResult> DeletePessoas(
            [FromServices] DataContext _context, int id)
        {
            var pessoas = await _context.Pessoas.FindAsync(id);
            if (pessoas == null)
            {
                return NotFound("Pessoa não encontrada para excluir");
            }

            _context.Pessoas.Remove(pessoas);
            await _context.SaveChangesAsync();

            return Ok("Pessoa foi excluida com sucesso");
        }
    }
}
