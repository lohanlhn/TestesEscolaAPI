using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.Models
{
    [Table("Alunos")]
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        [Column(TypeName ="Date")]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<AlunoTurma> AlunosTurmas { get; set; }
    }
}
