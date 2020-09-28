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
    public class TurmasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public TurmasController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Turma>> Get()
        {
            return _uof.TurmaRepository.Get().ToList();
        }

        [HttpGet("{id}", Name = "ObterTurma")]
        public ActionResult<Turma> GetById(int id)
        {
            var turma = _uof.TurmaRepository.GetById(a => a.TurmaId == id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Turma turma)
        {
            _uof.TurmaRepository.Add(turma);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterTurma", new { id = turma.TurmaId }, turma);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Turma turma)
        {
            if (id != turma.TurmaId)
            {
                return BadRequest();
            }
            _uof.TurmaRepository.Update(turma);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Turma> Delete(int id)
        {
            var turma = _uof.TurmaRepository.GetById(a => a.TurmaId == id);

            if (turma == null)
            {
                return NotFound();
            }

            _uof.TurmaRepository.Delete(turma);
            _uof.Commit();
            return turma;
        }
    }
}
