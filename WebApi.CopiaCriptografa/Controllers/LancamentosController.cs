using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.CopiaCriptografa.Data;
using WebApi.CopiaCriptografa.Models;

namespace WebApi.CopiaCriptografa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentosController : Controller
    {
        private readonly DbContextLancCripto _context;

        public LancamentosController(DbContextLancCripto context)
        {
            _context = context;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lancamento>>> GetLancamentos()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Lancamento>> GetLancamentos(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            return lancamento;
        }

        #endregion

        #region Post

        [HttpPost]
        public async Task<ActionResult<Lancamento>> PostLancamentos(Lancamento lancamentos)
        {
            _context.Lancamentos.Add(lancamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLancamentos", new { id = lancamentos.Id }, lancamentos);
        }

        #endregion

        #region Put

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLancamentos(Lancamento lancamentos)
        {
            _context.Entry(lancamentos).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok(lancamentos);
        }

        #endregion

        #region Delete

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLancamentos(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);

            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();

            return Ok("Lancamento foi excluida com sucesso");
        }

        #endregion
    }
}
