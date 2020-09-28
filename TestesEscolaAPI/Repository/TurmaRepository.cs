using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.Models;

namespace TestesEscolaAPI.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
