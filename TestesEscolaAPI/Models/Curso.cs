using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.Models
{
    [Table("Cursos")]
    public class Curso
    {
        [Key]
        public int CursoId { get; set; }    
        [Required]
        [MaxLength(20)]
        public string Turno { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
