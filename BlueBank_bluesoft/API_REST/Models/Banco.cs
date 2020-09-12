using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Models
{
    public class Banco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Nombre { get; set; }
    }
}
