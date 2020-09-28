using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.Models;

namespace TestesEscolaAPI.Repository
{
    public class AlunoTurmaRepository : Repository<AlunoTurma>, IAlunoTurmaRepository
    {
        public AlunoTurmaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
