using API_REST.Controllers;
using API_REST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace API_REST.TEST.Pruebas_Unitarias
{
    [TestClass]
    public class CuentaControllerTest : BasePruebas
    {

        /*Las pruebas que realizamos las hacemos desde diferentes base de datos, usamos para el ejemplo strings aleatorio*/

        [TestMethod]
        public async Task ObtenerTodosLasCuentas()
        {
            //preparacion

            var nombreBd = Guid.NewGuid().ToString(); //En este caso generamos un nombre de base de datos aleatorio
            var contexto = ConstruirContexto(nombreBd);

            contexto.TipoCuentas.Add(new TipoCuenta() { Nombre = "Ahorros" });
            contexto.Bancos.Add(new Banco() { Nombre = "Caja social" });
            contexto.Personas.Add(new Persona() { Nombre = "Daniel", Apellido = "Marquez", FechaNacimiento = DateTime.Now, No = "5678787532", Celular = "3212321212" });
            contexto.Cuentas.Add(new Cuenta() { NumeroCuenta = "234324", ValorInicial = 100, Clave = "2323", TipoCuenta = 1, Banco = 1, Persona = 1 });
            contexto.Cuentas.Add(new Cuenta() { NumeroCuenta = "343234", ValorInicial = 20500, Clave = "1234", TipoCuenta = 1, Banco = 1, Persona = 1 });

            await contexto.SaveChangesAsync();
            var context2 = ConstruirContexto(nombreBd);

            //prueba

            var controller = new CuentaController(context2);
            var respuesta = await controller.GetCuentas();

            //verificacion

            var cuentas = respuesta.Value;
            Assert.AreEqual(2, cuentas.Count);  //verifica que el listado de cuentas devuelto tiene 2 cuentas
        }

        [TestMethod]
        public async Task ObtenerCuentaPorIdNoExistente()
        {
            //preparacion

            var nombreBd = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBd);

            //prueba

            var controller = new CuentaController(contexto);
            var respuesta = await controller.GetCuenta(1);

            //No creamos nninguna cuenta en la base de datos

            //verificacion

            var resultado = respuesta.Result as StatusCodeResult;  // casteamos a status code, ya que not found en mi controller CuentaController es tipo status code
            Assert.AreEqual(404, resultado.StatusCode); //verifica que el id cuenta no se encuentra, not found
        }

        [TestMethod]
        public async Task ObtenerCuentaIdExistente()
        {
            //preparacion

            var nombreBd = Guid.NewGuid().ToString();     //base de datos 1
            var contexto = ConstruirContexto(nombreBd);

            contexto.Cuentas.Add(new Cuenta() { NumeroCuenta = "234324", ValorInicial = 100, Clave = "2323", TipoCuenta = 1, Banco = 1, Persona = 1 }); // agregamos cuenta a la abase de datos
            contexto.SaveChanges();

            //prueba

            var contexto2 = ConstruirContexto(nombreBd);  // nueva base de datos 2
            var controller = new CuentaController(contexto2);

            //verificacion

            var id = 1;
            var respuesta = await controller.GetCuenta(id);
            var resultado = respuesta.Value;

            Assert.AreEqual(id, resultado.Id); //verificamos que el id de la cuenta sea igual al id instancia
        }

        [TestMethod]
        public async Task CrearCuenta()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBd);

            var nuevaCuenta = new Cuenta() { NumeroCuenta = "234324", ValorInicial = 100, Clave = "2323", TipoCuenta = 1, Banco = 1, Persona = 1 };
            var controller = new CuentaController(contexto);

            var respuesta = await controller.PostCuenta(nuevaCuenta);

            Assert.IsNotNull(respuesta); //verifica que se creo una cuenta y no es null

            var contexto2 = ConstruirContexto(nombreBd);
            var cantidad = await contexto2.Cuentas.CountAsync();
            Assert.AreEqual(1, cantidad); //verifica que la cantidad de registros creados en la base de datos es 1
        }

        [TestMethod]
        public async Task ActualizarCuenta()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBd);

            var cuenta = new Cuenta() { NumeroCuenta = "234324", ValorInicial = 100, Clave = "2323", TipoCuenta = 1, Banco = 1, Persona = 1 };
            contexto.Cuentas.Add(cuenta); 
            await contexto.SaveChangesAsync(); //registramos la cuenta

            var contexto2 = ConstruirContexto(nombreBd);

            //Editamos la cuenta que se registro
            var id = 1;
            cuenta.NumeroCuenta = "234324";
            cuenta.ValorInicial = 100;
            cuenta.Clave = "0000";
            cuenta.TipoCuenta = 1;
            cuenta.Banco = 1;
            cuenta.Persona = 1;

            var controller = new CuentaController(contexto2);

            var respuesta = await controller.PutCuenta(id,cuenta); 

            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(204,resultado.StatusCode);  //verificamos que se modifico la cuenta

            var contexto3 = ConstruirContexto(nombreBd);
            var existe = await contexto3.Cuentas.AnyAsync(x => x.Clave == "0000");

            Assert.IsTrue(existe);  //verificamos que existe una cuenta con la nueva clave actualizada en la base de datos
        }

        [TestMethod]
        public async Task IntentaBorrarGeneroNoExistente()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBd);

            var controller = new CuentaController(contexto);

            var respuesta = await controller.DeleteCuenta(1);
            var resultado = respuesta.Result as StatusCodeResult;

            Assert.AreEqual(404,resultado.StatusCode); //verifica que no se puede eliminar la cuenta
        }

        [TestMethod]
        public async Task BorrarCuenta()
        {
            var nombreBd = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBd);

            contexto.Cuentas.Add(new Cuenta() { NumeroCuenta = "234324", ValorInicial = 100, Clave = "2323", TipoCuenta = 1, Banco = 1, Persona = 1 });
            await contexto.SaveChangesAsync(); //registramos la cuenta a eliminar

            var contexto2 = ConstruirContexto(nombreBd);
            var controller = new CuentaController(contexto2);

            var respuesta = await controller.DeleteCuenta(1);
            var resultado = respuesta.Result as StatusCodeResult;

            Assert.AreEqual(204, resultado.StatusCode); //verifica que se elimino la cuenta

            var contexto3 = ConstruirContexto(nombreBd);
            var existe = await contexto3.Cuentas.AnyAsync(); //AnyAsync, return false porque no contiene elementos de tipo cuenta
            Assert.IsFalse(existe); //verifica que no existan cuentas 
        }
    }
}
