namespace api.Entidades
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AuthorBook> AuthorBooks { get; set; }
    }
}
