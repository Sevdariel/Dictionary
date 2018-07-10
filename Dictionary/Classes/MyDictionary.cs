using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dictionary
{
    public class MyDictionary : IMyDictionary
    {
        private readonly IDataPrepare _dataPrepare;
        private readonly IWordDictionary _wordDictionary;

        public List<Word> wordList;

        public MyDictionary(IDataPrepare dataPrepare, IWordDictionary wordDictionary)
        {
            _dataPrepare = dataPrepare;
            _wordDictionary = wordDictionary;
        }

        public void Show()
        {
            wordList = _wordDictionary.GetWordDictionary();

            Console.WriteLine("\n");
            foreach (var word in wordList)
            {
                Console.WriteLine(word.Polish + " - " + word.English);
            }
            Console.WriteLine("\n");
        }

        public void Add()
        {
            Console.WriteLine("Podaj formule (EN-PL/e) or (PL-EN/p)");
            string key = Console.ReadLine().ToLower();
            switch (key)
            {
                case "e":
                    EnToPl();
                    _dataPrepare.Save();
                    break;
                case"p":
                    PlToEn();
                    _dataPrepare.Save();
                    break;
            }
            Show();
        }

        public void Edit()
        {
        }

        public void Find()
        {
            Console.WriteLine("Chcesz znalezc angielskie (e) tlumaczenie czy polskie (p)\n");
            string key = Console.ReadLine().ToLower();
            switch (key)
            {
                case "e":
                    FindEn();
                    break;
                case "p":
                    FindPl();
                    break;
            }
        }

        private void FindPl()
        {
            Word word = new Word();
            bool flag = false;
            Console.WriteLine("Podaj angielski wyraz");
            word.English = Console.ReadLine().ToString().ToLower();
            foreach (var englishWord in _wordDictionary.GetWordDictionary())
            {
                if (englishWord.English == word.English)
                {
                    Console.WriteLine(englishWord.Polish + " - " + englishWord.English);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Console.WriteLine("Nie ma takiego slowa");
        }

        private void FindEn()
        {
            Word word = new Word();
            bool flag = false;
            Console.WriteLine("Podaj polski wyraz");
            word.Polish = Console.ReadLine().ToString().ToLower();
            foreach (var polishWord in _wordDictionary.GetWordDictionary())
            {
                if (polishWord.Polish == word.Polish)
                {
                    Console.WriteLine(polishWord.English + " - " + polishWord.Polish);
                    flag = true;
                    break;
                }
            }
            if (!flag)
                Console.WriteLine("Nie ma takiego słowa");
        }

        private void EnToPl()
        {
            Word word = new Word();
            Console.WriteLine("Podaj angielski wyraz");
            word.English = Console.ReadLine().ToString().ToLower();
            Console.WriteLine("Podaj polskie tlumaczenie");
            word.Polish = Console.ReadLine().ToString().ToLower();
            if (_wordDictionary.CheckWord(word))
                Console.WriteLine("Taki wyraz juz istnieje");
        }

        private void PlToEn()
        {
            Word word = new Word();
            Console.WriteLine("Podaj polski wyraz");
            word.Polish = Console.ReadLine().ToLower();
            Console.WriteLine("Podaj angielskie tlumaczenie");
            word.English = Console.ReadLine().ToLower();
            if (_wordDictionary.CheckWord(word))
                Console.WriteLine("Taki wyraz juz istnieje");
        }
    }
}
