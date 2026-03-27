using System.Security.Authentication.ExtendedProtection;
using System.Threading.Channels;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            MainMenu menu = new MainMenu(client);
            menu.LoadMenu();
            while (true) { };
            Console.ReadLine();
        }
    }
}
