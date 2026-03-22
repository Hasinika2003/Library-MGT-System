public class Book
{

    public int BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }

    public Book(int id, string title , string author)
    {
        BookId = id;
        Title = title;
        Author = author;
        IsBorrowed = false;
    }

}
