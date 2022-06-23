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
        public List<bool> Done { get; set; }

        protected int points = 0;
        
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
        
        public ListaVerbi getListaVerbi()
        {
            return ListaDeiVerbi;
        }
        public int getNumVerbi()
        {
            return ListaDeiVerbi.Count();
        }
        public void Add(Verbo verb)
        {
            if (ListaDeiVerbi.Add(verb))
            {
                using (Stream stream = File.Open("ListaVerbi.xml", FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, ListaDeiVerbi);
                }
            }
            else
                MessageBox.Show("Errore: verbo già presente");
        }
        public void Remove(string presente)
        {
            if (ListaDeiVerbi.Remove(presente))
            {
                using (Stream stream = File.Open("ListaVerbi.xml", FileMode.Open))
                {
                    var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    bformatter.Serialize(stream, ListaDeiVerbi);
                }
            }
            else
                MessageBox.Show("Errore: verbo non presente");
        }
        public int[] returnPoints()
        {
            int doneVerbs = Done.Count(item => item == true);
            return new int[2] { points, doneVerbs };
        }
        public ListaVerbi StartTest()
        {
            points = 0;
            Done = new List<bool> { };
            for (int i = 0; i< ListaDeiVerbi.Count(); i++)
            {
                Done.Add(false);
            }
            
            return ListaDeiVerbi.shuffle();
        }
        public void addPoints(int pts)
        {
            points += pts;
        }

    }
    public static class SeriouslyRandom
    {
        /// <summary>
        /// Holds the current seed value.
        /// </summary>
        private static int seed = Environment.TickCount;

        /// <summary>
        /// Holds a separate instance of Random per thread.
        /// </summary>
        private static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() =>
                new Random(Interlocked.Increment(ref seed)));

        /// <summary>
        /// Returns a Seriously Random value.
        /// </summary>
        public static int Next(int minValue, int maxValue)
        {
            return random.Value.Next(minValue, maxValue);
        }
    }
}
