using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestesEscolaAPI.Context;
using TestesEscolaAPI.DTOs;
using TestesEscolaAPI.Models;
using TestesEscolaAPI.Repository;

namespace TestesEscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;
        public AlunosController(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AlunoDTO>> Get()
        {
            var alunos = _uof.AlunoRepository.Get().ToList();
            var alunosDTO = _mapper.Map<List<AlunoDTO>>(alunos);

            return alunosDTO;
        }

        [HttpGet("{id}", Name = "ObterAluno")]
        public ActionResult<AlunoDTO> GetById(int id)
        {            
            var aluno = _uof.AlunoRepository.GetById(a => a.AlunoId == id);

            if (aluno == null)
            {
                return NotFound();
            }

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return alunoDTO;
        }

        [HttpPost]
        public ActionResult Post([FromBody] AlunoDTO alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);

            aluno.Nome = aluno.Nome.ToUpper();
            _uof.AlunoRepository.Add(aluno);
            _uof.Commit();

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return new CreatedAtRouteResult("ObterAluno", new { id = aluno.AlunoId }, alunoDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Aluno alunoDto)
        {
            if(id != alunoDto.AlunoId)
            {
                return BadRequest();
            }

            var aluno = _mapper.Map<Aluno>(alunoDto);

            _uof.AlunoRepository.Update(aluno);
            _uof.Commit();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<AlunoDTO> Delete(int id)
        {
            var aluno = _uof.AlunoRepository.GetById(a => a.AlunoId == id);

            if(aluno == null)
            {
                return NotFound();
            }

            _uof.AlunoRepository.Delete(aluno);
            _uof.Commit();

            var alunoDTO = _mapper.Map<AlunoDTO>(aluno);

            return alunoDTO;
        }
    }
}
