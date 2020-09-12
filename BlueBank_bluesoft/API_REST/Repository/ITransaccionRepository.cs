using API_REST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repository
{
    public interface ITransaccionRepository
    {
        public Task<List<Transaccion>> GetTransaccionesAsync();

        public Task<Transaccion> PostTransaccion(Transaccion transaccion);
    }
}
