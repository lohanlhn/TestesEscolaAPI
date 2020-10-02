using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.DTOs
{
    public class TurmaDTO
    {
        public int TurmaId { get; set; }        
        public string CodTurma { get; set; }
        public int CursoId { get; set; }        
    }
}
