using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_REST.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string No { get; set; }

        [Required]
        [Column(TypeName = "Varchar(10)")]
        public string Celular { get; set; }
    }
}
