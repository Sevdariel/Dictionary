using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Dictionary
{
    public class DataPrepare : IDataPrepare
    {
        private readonly IWordDictionary _wordDictionary;
        private XmlSerializer serializer;
        private FileStream data;
        public DataPrepare(IWordDictionary wordDictionary)
        {
            _wordDictionary = wordDictionary;
            CreateSerializer();
        }

        public void Load()
        {
            data = File.OpenRead("dictionary.xml");
            _wordDictionary.CreateWordDictionary(data, serializer);
            data.Close();
        }

        public void Save()
        {
            data = File.OpenWrite("dictionary.xml");
            serializer.Serialize(data, _wordDictionary.GetWordDictionary());
            data.Close();
        }

        private void CreateSerializer()
        {
            serializer = new XmlSerializer(typeof(List<Word>), new XmlRootAttribute("WordDictionary"));
        }
    }
}
