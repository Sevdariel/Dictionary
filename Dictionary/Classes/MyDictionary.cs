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
            _dataPrepare.Load();
            wordList = _wordDictionary.GetWordDictionary();

            foreach (var word in wordList)
            {
                Console.WriteLine(word.Polish + " - " + word.English);
            }
        }

        public void Add()
        {
            Console.WriteLine("Podaj formule (EN-PL/e) or (PL-EN/p)");
            string key = Console.ReadLine().ToString().ToLower();
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
        }

        public void Edit()
        {
        }

        public void EnToPl()
        {
            Console.WriteLine("Podaj angielski wyraz");
            string en = Console.ReadLine().ToString().ToLower();
            Console.WriteLine("Podaj polskie tlumaczenie");
            string pl = Console.ReadLine().ToString().ToLower();
            _wordDictionary.NewWordInDictionary(pl, en);
        }

        public void PlToEn()
        {
            Console.WriteLine("Podaj polski wyraz");
            string pl = Console.ReadLine().ToString().ToLower();
            Console.WriteLine("Podaj angielskie tlumaczenie");
            string en = Console.ReadLine().ToString().ToLower();
            _wordDictionary.NewWordInDictionary(pl, en);
        }
    }
}
