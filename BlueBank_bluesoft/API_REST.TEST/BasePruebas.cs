using API_REST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_REST.TEST
{
    public class BasePruebas
    {
        //Usamos un prooverdor de meorio para trabajar con dbContext
        //cada prueba unitarias es independiente una de la otra , es por eso que cada una se conecta a una base de datos distinta
        protected AppDbContext ConstruirContexto (string nombreDb)
        {
            var opciones = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(nombreDb).Options;

            var dbContext = new AppDbContext(opciones);
            return dbContext;
        }
    }
}
