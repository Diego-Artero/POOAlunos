using Api_Hexagonal.Data;
using Api_Hexagonal.Entities;
using Api_Hexagonal.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Api_Hexagonal.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly Context _database;

        public AlunoRepository(Context context)
        {
            _database = context;
        }

        public void Create(Aluno aluno)
        {
            _database.Alunos.Add(aluno);
            _database.SaveChanges();
        }

        public Aluno GetById(Guid Id)
        {
            return _database.Alunos
                .Select(aluno => aluno)
                .Where(aluno => aluno.Id == Id)
                .FirstOrDefault();
        }

        public List<Aluno> GetAll()
        {
            List<Aluno> list = _database.Alunos.Select(alunos => alunos).ToList();
            return list;
        }

        public void Update(Aluno aluno)
        {
            _database.Alunos.Update(aluno);
            _database.SaveChanges();
        }

        public void Delete(Aluno aluno)
        {
            _database.Alunos.Remove(aluno);
            _database.SaveChanges();
        }

        public Aluno GetByEmail(string email)
        {
            return _database.Alunos
                .Select(aluno => aluno)
                .Where(aluno => aluno.Email == email)
                .FirstOrDefault();
        }

        //Curso
        public void Matricular(Guid Id, Guid cursoId) 
        {
            var aluno = _database.Alunos.Find(Id);
            var curso = _database.Cursos.Find(cursoId);

            aluno.CursoId = cursoId;
            curso.Alunos.Add(aluno);
            _database.Cursos.Update(curso);
            _database.Alunos.Update(aluno);
            _database.SaveChanges();
        }
    }
}
