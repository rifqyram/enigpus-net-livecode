using Enigpus_1.Models;

namespace Enigpus_1.Services;

public interface IInventoryService
{
    void AddBook(Book book);
    List<Book> SearchBook(string title);
    List<Book> GetAllBook();
}