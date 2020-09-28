using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Context;

namespace TestesEscolaAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AlunoRepository _alunoRepository;
        private TurmaRepository _turmaRepository;
        private CursoRepository _cursoRepository;
        private AlunoTurmaRepository _alunoTurmaRepository;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAlunoRepository AlunoRepository
        {
            get
            {
                return _alunoRepository = _alunoRepository ?? new AlunoRepository(_context);
            }
        }

        public ITurmaRepository TurmaRepository 
        {
            get
            {
                return _turmaRepository = _turmaRepository ?? new TurmaRepository(_context);
            }
        }

        public ICursoRepository CursoRepository
        {
            get
            {
                return _cursoRepository = _cursoRepository ?? new CursoRepository(_context);
            }
        }

        public IAlunoTurmaRepository AlunoTurmaRepository
        {
            get
            {
                return _alunoTurmaRepository = _alunoTurmaRepository  ?? new AlunoTurmaRepository(_context);
            }
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
