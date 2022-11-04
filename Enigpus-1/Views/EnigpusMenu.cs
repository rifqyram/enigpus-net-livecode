using Enigpus_1.Models;
using Enigpus_1.Services;

namespace Enigpus_1.Views;

public class EnigpusMenu
{
    private IInventoryService _service;

    public EnigpusMenu(IInventoryService service)
    {
        _service = service;
    }
    
    public void MainMenu()
    {
        var run = true;

        while (run)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("===== WELCOME TO ENIGPUS INVENTORY =====");
            Console.WriteLine("========================================");

            Console.WriteLine(@"Pilih menu dibawah ini:
1. Tambahkan Buku
2. Lihat isi Buku
3. Mencari Buku berdasarkan Judul
4. Keluar dari Aplikasi");

            Console.Write("Pilih Menu: ");
            switch (Console.ReadLine())
            {
                case "1":
                    CreateBookMenu();
                    break;
                case "2":
                    ViewListBook();
                    break;
                case "3":
                    SearchBookByTitle();
                    break;
                case "4":
                    run = false;
                    break;
            }
        }
    }

    private void CreateBookMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("====================");
            Console.WriteLine("Inputkan Jenis Buku:");
            Console.WriteLine("====================");
            Console.WriteLine(@"1. Novel
2. Majalah");

            Console.Write("Inputkan Jenis Buku: ");
            switch (Console.ReadLine())
            {
                case "1":
                    // Buat novel
                    CreateNewNovel();
                break;
                case "2":
                    // buat magazine
                    CreateNewMagazine();
                break;
                default:
                    return;
            }
        }
    }

    private void CreateNewNovel()
    {
        Console.Write("Inputkan Code Buku: ");
        var code = Console.ReadLine();
        Console.Write("Inputkan Judul Buku: ");
        var title = Console.ReadLine();
        Console.Write("Inputkan Penerbit Buku: ");
        var publisher = Console.ReadLine();
        Console.Write("Inputkan Tahun Terbit Buku: ");
        var publicationYear = Convert.ToInt32(Console.ReadLine());
        Console.Write("Inputkan Penulis Buku: ");
        var author = Console.ReadLine();

        Novel novel = new Novel
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            PublicationYear = publicationYear,
            Author = author
        };
        
        _service.AddBook(novel);
    }

    private void CreateNewMagazine()
    {
        Console.Write("Inputkan Code Buku: ");
        var code = Console.ReadLine();
        Console.Write("Inputkan Judul Buku: ");
        var title = Console.ReadLine();
        Console.Write("Inputkan Penerbit Buku: ");
        var publisher = Console.ReadLine();
        Console.Write("Inputkan Tahun Terbit Buku: ");
        var publicationYear = Convert.ToInt32(Console.ReadLine());

        Book magazine = new Magazine()
        {
            Code = code,
            Title = title,
            Publisher = publisher,
            PublicationYear = publicationYear,
        };
        
        _service.AddBook(magazine);
    }

    private void ViewListBook()
    {
        var books = _service.GetAllBook();

        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

    private void SearchBookByTitle()
    {
        Console.Write("Inputkan Judul buku yang ingin dicari: ");
        var title = Console.ReadLine();
        var books = _service.SearchBook(title);

        if (!books.Any())
        {
            Console.WriteLine("Books Empty");
            return;
        }
        
        foreach (var book in books)
        {
            Console.WriteLine(book);
        }
    }

}