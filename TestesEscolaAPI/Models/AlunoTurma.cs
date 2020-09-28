using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.Models
{
    [Table("AlunosTurmas")]
    public class AlunoTurma
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }

    }
}
