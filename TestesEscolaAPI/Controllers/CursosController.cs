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
    public class CursosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public CursosController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Curso>> Get()
        {
            return _uof.CursoRepository.Get().ToList();
        }

        [HttpGet("{id}", Name = "ObterCurso")]
        public ActionResult<Curso> GetById(int id)
        {
            var curso = _uof.CursoRepository.GetById(a => a.CursoId == id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Curso curso)
        {
            _uof.CursoRepository.Add(curso);
            _uof.Commit();

            return new CreatedAtRouteResult("ObterCurso", new { id = curso.CursoId }, curso);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Curso curso)
        {
            if (id != curso.CursoId)
            {
                return BadRequest();
            }
            _uof.CursoRepository.Update(curso);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Curso> Delete(int id)
        {
            var curso = _uof.CursoRepository.GetById(a => a.CursoId == id);

            if (curso == null)
            {
                return NotFound();
            }

            _uof.CursoRepository.Delete(curso);
            _uof.Commit();
            return curso;
        }
    }
}
