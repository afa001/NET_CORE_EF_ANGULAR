using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Models
{
    public class Transaccion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(15)")]
        public string Tipo { get; set; } //consginacion, retiro

        [Column(TypeName = "Varchar(15)")]
        public string NumeroCuentaTransaccion { get; set; } //if consignacion

        [Required]
        public int Cuenta { get; set; }

        [Required]
        public long Valor { get; set; } //if consignacion
    }
}
