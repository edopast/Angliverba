using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Angliverba
{
    public class Tester
    {
        protected ListaVerbi ListaDeiVerbi { get; set; }
        protected List<bool> Done { get; set; }
        public int points = 0;
        public Tester()
        {
            ListaDeiVerbi= new ListaVerbi();

            // read or create ListaVerbi.xml
            if (File.Exists("ListaVerbi.xml"))
            {
                using (Stream stream = File.Open("ListaVerbi.xml", FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                    ListaDeiVerbi = (ListaVerbi)bformatter.Deserialize(stream);
                }
            }
            else
            {
                ListaDeiVerbi.Add(new Verbo("go", new List<string> { "went" }, new List<string> { "gone" }, new List<string> { "andare" }));
                ListaDeiVerbi.Add(new Verbo("eat", new List<string> { "ate" }, new List<string> { "eaten" }, new List<string> { "mangiare" }));
                using (Stream stream = File.Open("ListaVerbi.xml", FileMode.Create))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, ListaDeiVerbi);
                }
            }
        }
    }
}
