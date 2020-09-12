using API_REST.DataContext;
using API_REST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repository
{
    public class TransaccionRepository : ITransaccionRepository
    {
        public readonly AppDbContext _context;
        public TransaccionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaccion>> GetTransaccionesAsync()
        {
            var transacciones = new List<Transaccion>();

            try
            {
                transacciones = await _context.Transacciones.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return transacciones;
        }

        public async Task<Transaccion> PostTransaccion(Transaccion transaccion)
        {
            try
            {
                _context.Transacciones.Add(transaccion);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return transaccion;
        }
    }
}
