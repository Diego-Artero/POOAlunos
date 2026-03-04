using Api_Fullstack_Aluno.DTOs.CursoDTOs;
using Api_Hexagonal.DTOs.AlunoDTOs;
using Api_Hexagonal.DTOs.CursoDTOs;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Api_Hexagonal.Interfaces.IServices;

namespace Api_Hexagonal.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _repository;

        public CursoService(ICursoRepository repository)
        {
            _repository = repository;
        }
        public void CreateCurso(CreateCursoDTO cursoDTO)
        {
            try
            {
                Curso newCurso = new Curso();

                newCurso.Id = Guid.NewGuid();
                newCurso.Name = cursoDTO.Name;
                newCurso.Description = cursoDTO.Description;
                _repository.Create(newCurso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curso GetById(Guid Id)
        {
            try
            {
                Curso curso = _repository.GetById(Id);

                if (curso == null)
                {
                    throw new Exception("Aluno não encontrado");
                }

                return curso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CursoResponseDto> ListCursos()
        {
            List<CursoResponseDto> list = _repository.GetAll();
            return list;
        }

        public void UpdateCurso(Guid id, UpdateCursoDTO cursoDTO)
        {
            try
            {
                Curso updateCurso = new Curso();

                updateCurso.Id = Guid.NewGuid();
                updateCurso.Name = cursoDTO.Name;
                updateCurso.Description = cursoDTO.Description;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteCurso(Guid Id)
        {
            Curso curso = _repository.GetById(Id);

            if (curso == null)
            {
                throw new Exception("Curso não encontrado");
            }

            _repository.Delete(curso);
        }
    }
}
