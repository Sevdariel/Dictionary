using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dictionary
{
    [XmlRoot("WordDictionary")]
    public class Word
    {
        public string Polish { get; set; }
        public string English { get; set; }
    }
}
