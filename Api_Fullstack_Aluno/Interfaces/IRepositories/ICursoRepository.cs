using Api_Fullstack_Aluno.DTOs.CursoDTOs;
using Api_Hexagonal.DTOs;
using Api_Hexagonal.Entities;

namespace Api_Hexagonal.Interfaces.IRepositories
{
    public interface ICursoRepository
    {
        public void Create(Curso curso);
        public Curso GetById(Guid Id);
        public List<CursoResponseDto> GetAll();
        public void Update(Curso curso);
        public void Delete(Curso curso);
    }
}
