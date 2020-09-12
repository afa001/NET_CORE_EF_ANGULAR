using API_REST.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)
        {

        }

        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<TipoCuenta> TipoCuentas { get;set; }
        public DbSet<Transaccion> Transacciones { get; set; }
    }
}
