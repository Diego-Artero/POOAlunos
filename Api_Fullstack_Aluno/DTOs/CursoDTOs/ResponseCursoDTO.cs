namespace Api_Fullstack_Aluno.DTOs.CursoDTOs
{
    public class CursoResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Alunos { get; set; }
    }
}