using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.DTOs
{
    public class AlunoDTO
    {        
        public int AlunoId { get; set; }        
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }        
        public string Email { get; set; }        
    }
}
