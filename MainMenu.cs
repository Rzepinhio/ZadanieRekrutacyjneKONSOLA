using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal class MainMenu
    {
        private readonly HttpClient _httpClient;
        private CatFactFetcher _catFactFetcher;
        private CatFactResponse catFactResponse;
        private FileSaver _fileSaver;
        private string catFactsFilePath = "catFacts.txt";

        public MainMenu(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _fileSaver = new FileSaver();
        }
        public void LoadMenu()
        {
            Console.Clear();
            Console.WriteLine("Zadanie rekrutacyjne NetWise:  Jakub Rzepa");
            Console.WriteLine();
            Console.WriteLine("Wybierz dzialanie: ");
            Console.WriteLine("1. Wyslij request");
            Console.WriteLine("2. Wyswietl zawartosc wszystkich odpowiedzi z pliku");
            Console.WriteLine("3. Zamknij program");
            HandleUserMenuInput();
        }

        private async Task HandleUserMenuInput()
        {
            Console.WriteLine();
            Console.Write("Opcja: ");
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 3)
            {
                switch (input)
                {
                    case 1:
                        HandleConnectionResponse();
                        break;
                    case 2:
                        ReadEverythingFromFile(catFactsFilePath);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wybierz odpowiednia opcje!");
                HandleUserMenuInput();
            }
        }

        private async Task HandleConnectionResponse()
        {
            _catFactFetcher = new CatFactFetcher(_httpClient);
            catFactResponse = await _catFactFetcher.ConnectAsync();
            if (catFactResponse != null)
            {
                _fileSaver.SaveFact(catFactResponse.Fact);
                Console.WriteLine("Pomyslnie polaczano!");
                Console.WriteLine("1. Wyslij ponownie");
                Console.WriteLine("2. Wyswietl zawartosc odpowiedzi tutaj");
                Console.WriteLine("3. Wyswietl zawartosc wszystkich odpowiedzi z pliku");
                Console.WriteLine("4. Wroc do menu");
                HandleUserActionInput();
            }
            else
            {
                Console.WriteLine("Blad polaczenia...");
                Console.WriteLine("Wcisnij dowlony przycisk, aby zrestartowac program...");
                Console.ReadKey();
                LoadMenu();
            }
        }


        private void HandleUserActionInput()
        {
            Console.WriteLine();
            Console.Write("Opcja: ");
            if (int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 4)
            {
                switch (input)
                {
                    case 1:
                        HandleConnectionResponse();
                        break;
                    case 2:
                        Console.WriteLine(catFactResponse.Fact);
                        Console.ReadKey();
                        LoadMenu();
                        break;
                    case 3:
                        ReadEverythingFromFile(catFactsFilePath);
                        break;
                    case 4:
                        LoadMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Wybierz odpowiednia opcje!");
                HandleUserActionInput();
            }
        }

        void ReadEverythingFromFile(string path)
        {
            if (!System.IO.File.Exists(path))
            {
                Console.WriteLine("Plik nie istnieje!");
                Console.WriteLine("Wcisnij dowlony przycisk, aby kontynuowac...");
                Console.ReadKey();
                LoadMenu();
                return;
            }

            StreamReader sr = new StreamReader(path);
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine();
            Console.WriteLine("Wcisnij dowlony przycisk, aby kontynuowac...");
            Console.ReadKey();
            LoadMenu();
        }
    }
}
