namespace api.Entidades
{
    public class Instrutor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Curso> Cursos { get; set; }
    }
}
