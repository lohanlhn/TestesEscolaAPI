using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestesEscolaAPI.Repository
{
    public interface IUnitOfWork
    {
        IAlunoRepository AlunoRepository { get; }
        ITurmaRepository TurmaRepository { get; }
        ICursoRepository CursoRepository { get; }
        IAlunoTurmaRepository AlunoTurmaRepository { get; }

        void Commit();
    }
}
