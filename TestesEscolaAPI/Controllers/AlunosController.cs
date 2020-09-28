using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.Models;
using TestesEscolaAPI.Repository;

namespace TestesEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public AlunosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> Get()
        {
            return _uof.AlunoRepository.Get().ToList();
        }

        [HttpGet("{id}", Name = "ObterAluno")]
        public ActionResult<Aluno> GetById(int id)
        {            
            var aluno = _uof.AlunoRepository.GetById(a => a.AlunoId == id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Aluno aluno)
        {
            aluno.Nome = aluno.Nome.ToUpper();
            _uof.AlunoRepository.Add(aluno);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterAluno", new { id = aluno.AlunoId }, aluno);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Aluno aluno)
        {
            if(id != aluno.AlunoId)
            {
                return BadRequest();
            }
            _uof.AlunoRepository.Update(aluno);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Aluno> Delete(int id)
        {
            var aluno = _uof.AlunoRepository.GetById(a => a.AlunoId == id);

            if(aluno == null)
            {
                return NotFound();
            }

            _uof.AlunoRepository.Delete(aluno);
            _uof.Commit();
            return aluno;
        }
    }
}
