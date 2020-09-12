using API_REST.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repository
{
    public interface ICuentaRepository
    {
        public Task<List<Cuenta>> GetCuentasAsync();

        public Task<Cuenta> GetCuentaAsync(int id);

        public Task<Cuenta> PostCuentaAsync(Cuenta cuenta);

        public Task<Cuenta> PutCuentaAsync(int id, Cuenta cuenta);

        public Task<Cuenta> DeleteCuentaAsync(int id);

        public Task<Cuenta> ActualizarSaldo(Transaccion transaccion, Cuenta cuenta);

    }
}
