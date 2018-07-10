using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dictionary
{
    [Serializable]
    public class WordDictionary : IWordDictionary
    {
        public List<Word> wordList;
    
        public void CreateWordDictionary(System.IO.FileStream data, System.Xml.Serialization.XmlSerializer serializer)
        {
 	        wordList = (List<Word>)serializer.Deserialize(data);
        }

        public void NewWordInDictionary(Word word)
        {
            wordList.Add(word);
        }

        public bool CheckWord(Word word)
        {
            if (!wordList.Contains(word))
            {
                NewWordInDictionary(word);
                return true;
            }
            Console.WriteLine(word.Polish + " - " + word.English);
            return false;
        }

        public void FindWordInDictionary()
        {

        }

        public List<Word> GetWordDictionary()
        {
            return wordList;
        }
    }
}
