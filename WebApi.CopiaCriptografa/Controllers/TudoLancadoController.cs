using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.CopiaCriptografa.Data;
using WebApi.CopiaCriptografa.Models;

namespace WebApi.CopiaCriptografa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TudoLancadoController : Controller
    {
        private readonly DbContextLancCripto _context;

        public TudoLancadoController(DbContextLancCripto context)
        {
            _context = context;
        }

        #region Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TudoLancado>>> GetTudoLancados()
        {
            return await _context.TudoLancados.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TudoLancado>> GetTudoLancados(int id)
        {
            var tudoLancado = await _context.TudoLancados.FindAsync(id);

            tudoLancado.TextoCrypt = Decrypt(tudoLancado.TextoCrypt);

            return tudoLancado;
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<ActionResult<TudoLancado>> PostTudoLancados(TudoLancado tudoLancado)
        {
            var lancamento = await _context.Lancamentos
                .FirstOrDefaultAsync(obj => obj.Id == tudoLancado.Id);

            TudoLancado tudoLancadoNovo = new TudoLancado
            {
                TextoCrypt = Encrypt(lancamento.Texto),
                IdTexto = lancamento.Id
            };

            _context.TudoLancados.Add(tudoLancadoNovo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTudoLancados", new { id = tudoLancadoNovo.Id }, tudoLancadoNovo);
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTudoLancados(TudoLancado tudoLancados)
        {
            var lancamento = await _context.Lancamentos
                .FirstOrDefaultAsync(obj => obj.Id == tudoLancados.IdTexto);

            tudoLancados.TextoCrypt = Encrypt(lancamento.Texto);

            _context.Entry(tudoLancados).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return Ok(tudoLancados);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTudoLancados(int id)
        {
            var TudoLancado = await _context.TudoLancados.FindAsync(id);

            _context.TudoLancados.Remove(TudoLancado);
            await _context.SaveChangesAsync();

            return Ok("TudoLancado foi excluida com sucesso.");
        }
        #endregion

        #region Metodos Crypto
        public static string Encrypt(string textoCrypt)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(textoCrypt);
            return Convert.ToBase64String(byteArray);
        }

        public static string Decrypt(string textoCrypt)
        {
            byte[] byteArray = Convert.FromBase64String(textoCrypt);
            return Encoding.UTF8.GetString(byteArray);
        }
        #endregion
    }
}
