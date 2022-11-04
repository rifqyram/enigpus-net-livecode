using Enigpus_1.Services;
using Enigpus_1.Views;

public class Program
{
    public static void Main(string[] args)
    {
        IInventoryService service = new InventoryService();
        EnigpusMenu menu = new EnigpusMenu(service);
        menu.MainMenu();
    }
}