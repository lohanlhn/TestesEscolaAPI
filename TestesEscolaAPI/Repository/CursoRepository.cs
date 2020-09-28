using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.Models;

namespace TestesEscolaAPI.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
