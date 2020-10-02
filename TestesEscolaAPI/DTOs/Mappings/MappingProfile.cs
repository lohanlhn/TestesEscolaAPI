using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestesEscolaAPI.Models;

namespace TestesEscolaAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Curso, CursoDTO>().ReverseMap();
            CreateMap<Turma, TurmaDTO>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaDTO>().ReverseMap();
        }
    }
}
