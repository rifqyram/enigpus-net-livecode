using Enigpus_1.Models;

namespace Enigpus_1.Services;

public class InventoryService : IInventoryService
{
    // buat menyimpan 
    private List<Book> _books = new List<Book>();

    public void AddBook(Book book)
    {
        // gaboleh ada title yang sama
        _books.Add(book);
    }

    public List<Book> SearchBook(string title)
    {
        // 1. mencari - looping list nya
        // 2. conditional untuk mencari book by title
        List<Book> searchListBooks = new List<Book>(); // ini sebagai penampung

        foreach (var book in _books)
        {
            if (book.GetTitle().ToLower().Equals(title.ToLower()))
            {
                searchListBooks.Add(book);
            }
        }

        return searchListBooks;
    }

    public List<Book> GetAllBook()
    {
        return _books;
    }

    public void DeleteBook()
    {
        
    }
}