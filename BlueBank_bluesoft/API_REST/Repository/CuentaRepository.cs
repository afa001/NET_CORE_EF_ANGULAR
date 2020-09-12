using API_REST.DataContext;
using API_REST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Repository
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AppDbContext _context;
        public CuentaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Cuenta> GetCuentaAsync(int id)
        {
            var cuenta = new Cuenta();
            try
            {
                 cuenta = await _context.Cuentas.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }

            return cuenta;
        }

        public async Task<List<Cuenta>> GetCuentasAsync()
        {
            var cuentas = new List<Cuenta>();

            try
            {
                cuentas = await _context.Cuentas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cuentas;
        }

        public async Task<Cuenta> PostCuentaAsync(Cuenta cuenta)
        {
            try
            {
                _context.Cuentas.Add(cuenta);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cuenta;
        }

        public async Task<Cuenta> PutCuentaAsync(int id, Cuenta cuenta)
        {

            _context.Entry(cuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cuenta;
        }

        public async Task<Cuenta> DeleteCuentaAsync(int id)
        {
            var cuenta = new Cuenta();

            try
            {
                 cuenta = await _context.Cuentas.FindAsync(id);
                _context.Cuentas.Remove(cuenta);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return cuenta;
        }

        public  async Task<Cuenta> ActualizarSaldo(Transaccion transaccion, Cuenta cuenta)
        {
            if (transaccion.Tipo.Equals("Consignacion"))
            {
                long n = cuenta.ValorInicial += transaccion.Valor;
                _context.Entry(cuenta).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                if (transaccion.Tipo.Equals("Retiro"))
                {
                    long n = cuenta.ValorInicial -= transaccion.Valor;
                    _context.Entry(cuenta).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

            return cuenta;
        }
    }
}
