using System;
using System.Collections.Generic;
using System.Text;

namespace ZadanieRekrutacyjneKONSOLA
{
    internal class FileSaver : IFileSaver
    {
        public void SaveFact(string text)
        {
            //Nazwa pliku - format .txt
            string fileName = "catFacts.txt";

            // AppendAllText dopisuje tekst na końcu pliku
            // Jesli plik nie istnieje to go sam tworzy
            // Dodane \n na koncu, zeby skonczyc pismo w danej lini
            // Nastepny tekst bedzie dodano pod spodem
            File.AppendAllText(fileName, text + "\n");
        }
    }
}
