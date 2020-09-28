using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.Models;

namespace TestesEscolaAPI.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
