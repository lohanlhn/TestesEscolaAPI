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
    public class AlunosTurmasController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        public AlunosTurmasController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlunoTurma>> Get()
        {
            return _uof.AlunoTurmaRepository.Get().ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] AlunoTurma alunoTurma)
        {
            _uof.AlunoTurmaRepository.Add(alunoTurma);
            _uof.Commit();

            return Ok();
        }
    }
}
