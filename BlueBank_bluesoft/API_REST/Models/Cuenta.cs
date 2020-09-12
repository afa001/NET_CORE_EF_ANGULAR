using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Models
{
    public class Cuenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(15)")]
        public string NumeroCuenta { get; set; }

        [Required]
        public long ValorInicial { get; set; }

        [Required]
        [Column(TypeName = "Varchar(4)")]
        public string Clave { get; set; }

        [Required]
        public int TipoCuenta { get; set; }

        [Required]
        public int Banco { get; set; }
        
        [Required]
        public int Persona { get; set; }

    }
}
