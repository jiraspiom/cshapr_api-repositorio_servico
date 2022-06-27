namespace api.Entidades
{
    public class Curso
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int InstrutorId { get; set; }
        public Instrutor Instrutor { get; set; }
    }
}
