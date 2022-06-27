namespace api.Entidades
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<AuthorBook> AuthorsBook { get; set; }

    }
}
