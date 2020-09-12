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
    public class TipoCuentaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TipoCuentaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TipoCuenta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoCuenta>>> GetTipoCuentas()
        {
            return await _context.TipoCuentas.ToListAsync();
        }

        // GET: api/TipoCuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoCuenta>> GetTipoCuenta(int id)
        {
            var tipoCuenta = await _context.TipoCuentas.FindAsync(id);

            if (tipoCuenta == null)
            {
                return NotFound();
            }

            return tipoCuenta;
        }

        // PUT: api/TipoCuenta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoCuenta(int id, TipoCuenta tipoCuenta)
        {
            if (id != tipoCuenta.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoCuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCuentaExists(id))
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

        // POST: api/TipoCuenta
        [HttpPost]
        public async Task<ActionResult<TipoCuenta>> PostTipoCuenta(TipoCuenta tipoCuenta)
        {
            _context.TipoCuentas.Add(tipoCuenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoCuenta", new { id = tipoCuenta.Id }, tipoCuenta);
        }

        // DELETE: api/TipoCuenta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoCuenta>> DeleteTipoCuenta(int id)
        {
            var tipoCuenta = await _context.TipoCuentas.FindAsync(id);
            if (tipoCuenta == null)
            {
                return NotFound();
            }

            _context.TipoCuentas.Remove(tipoCuenta);
            await _context.SaveChangesAsync();

            return tipoCuenta;
        }

        private bool TipoCuentaExists(int id)
        {
            return _context.TipoCuentas.Any(e => e.Id == id);
        }
    }
}
