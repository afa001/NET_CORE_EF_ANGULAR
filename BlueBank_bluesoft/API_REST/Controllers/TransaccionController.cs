using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_REST.Models;
using API_REST.Repository;

namespace API_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly ICuentaRepository _cuentaRepository;

        public TransaccionController(ITransaccionRepository transaccionRepository, ICuentaRepository cuentaRepository)
        {
            _transaccionRepository = transaccionRepository;
            _cuentaRepository = cuentaRepository;
        }

        // GET: api/Transaccion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransacciones()
        {
            return await _transaccionRepository.GetTransaccionesAsync();
        }

        // POST: api/Transaccion
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
            var cuenta = await _cuentaRepository.GetCuentaAsync(transaccion.Cuenta);

            if (transaccion.Tipo.Equals("Retiro"))  
            {
                if (cuenta.ValorInicial > 0 && cuenta.ValorInicial >= transaccion.Valor) //valida valor total cuenta
                {
                    await _cuentaRepository.ActualizarSaldo(transaccion,cuenta);
                    await _transaccionRepository.PostTransaccion(transaccion);
                }
            }
            else
            {
                if (transaccion.Tipo.Equals("Consignacion"))
                {
                    await _cuentaRepository.ActualizarSaldo(transaccion,cuenta);
                    await _transaccionRepository.PostTransaccion(transaccion);
                }

            }

            return NoContent();
        }
    }
}
