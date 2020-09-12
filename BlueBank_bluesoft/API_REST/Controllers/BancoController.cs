using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_REST.Models;
using API_REST.DataContext;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BancoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Banco
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banco>>> GetBancos()
        {
            return await _context.Bancos.ToListAsync();
        }

        // GET: api/Banco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banco>> GetBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);

            if (banco == null)
            {
                return NotFound();
            }

            return banco;
        }

        // PUT: api/Banco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanco(int id, Banco banco)
        {
            if (id != banco.Id)
            {
                return BadRequest();
            }

            _context.Entry(banco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Banco
        [HttpPost]
        public async Task<ActionResult<Banco>> PostBanco(Banco banco)
        {
            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanco", new { id = banco.Id }, banco);
        }

        // DELETE: api/Banco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banco>> DeleteBanco(int id)
        {
            var banco = await _context.Bancos.FindAsync(id);
            if (banco == null)
            {
                return NotFound();
            }

            _context.Bancos.Remove(banco);
            await _context.SaveChangesAsync();

            return banco;
        }

        private bool BancoExists(int id)
        {
            return _context.Bancos.Any(e => e.Id == id);
        }
    }
}
