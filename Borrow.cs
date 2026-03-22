public class Borrow
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime BorrowDate { get; set; }

    public Borrow (int bookId, int userId)
    {
        BookId = bookId;
        UserId = userId;
        BorrowDate = DateTime.Now;
    }
}