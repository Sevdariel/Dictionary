using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dictionary
{
    public interface IWordDictionary
    {
        void CreateWordDictionary(FileStream data, XmlSerializer serializer);
        void NewWordInDictionary(Word word);
        void RemoveFromDictionary(Word word);
        void EditInDictionary(Word word);
        bool CheckWord(Word word);
        List<Word> GetWordDictionary();
    }
}
