using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.Models
{
    [Table("Turmas")]
    public class Turma
    {
        [Key]
        public int TurmaId { get; set; }
        [Required]
        [Column(TypeName = "char(3)")]        
        public string CodTurma { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public ICollection<AlunoTurma> AlunosTurmas { get; set; }
    }
}
