using System;
using System.Collections.Generic;
using System.Linq;
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

        public void NewWordInDictionary(string pl, string en)
        {
            Word word = new Word();
            word.Polish = pl;
            word.English = en;
            wordList.Add(word);
        }

        public List<Word> GetWordDictionary()
        {
            return wordList;
        }
    }
}
