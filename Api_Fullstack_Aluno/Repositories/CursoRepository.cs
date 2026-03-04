using Api_Fullstack_Aluno.DTOs.CursoDTOs;
using Api_Hexagonal.Data;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Repositories
{
    public class CursoRepository : ICursoRepository
    {
        public readonly Context _database;

        public CursoRepository(Context context)
        {
            _database = context;
        }
        public void Create(Curso curso)
        {
            _database.Cursos.Add(curso);
            _database.SaveChanges();
        }

        Curso ICursoRepository.GetById(Guid Id)
        {
            return _database.Cursos
                .Select(curso => curso)
                .Where(curso => curso.Id == Id)
                .FirstOrDefault();
        }

        public List<CursoResponseDto> GetAll()
        {
            return _database.Cursos
                .AsNoTracking()
                .Select(c => new CursoResponseDto
                {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    Alunos = c.Alunos
                        .Select(a => a.FirstName)
                        .ToList()
                })
                .ToList();
        }

        public void Update(Curso curso)
        {
            _database.Cursos.Update(curso);
            _database.SaveChanges();
        }

        public void Delete(Curso curso)
        {
            _database.Cursos.Remove(curso);
            _database.SaveChanges();
        }
    }
}
