using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API_REST.Models;
using API_REST.Repository;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaRepository _cuentaRepository;
        public CuentaController(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        // GET: api/Cuenta
        [HttpGet]
        public async Task<ActionResult<List<Cuenta>>> GetCuentas()
        {
            return await _cuentaRepository.GetCuentasAsync();
        }

        // GET: api/Cuenta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuenta>> GetCuenta(int id)
        {
            return await _cuentaRepository.GetCuentaAsync(id);
        }

        // PUT: api/Cuenta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuenta(int id, Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return BadRequest();
            }

            await _cuentaRepository.PutCuentaAsync(id,cuenta);

            return NoContent();
        }

        // POST: api/Cuenta
        [HttpPost]
        public async Task<ActionResult<Cuenta>> PostCuenta(Cuenta cuenta)
        {
            await _cuentaRepository.PostCuentaAsync(cuenta);
            return CreatedAtAction("GetCuenta", new { id = cuenta.Id }, cuenta);
        }

        // DELETE: api/Cuenta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cuenta>> DeleteCuenta(int id)
        {
            await _cuentaRepository.DeleteCuentaAsync(id);

            return NoContent();
        }
    }
}
