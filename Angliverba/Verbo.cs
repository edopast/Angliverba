using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angliverba
{
    [Serializable]
    public class Verbo
    {
        public string presente { get; }
        private List<string> passato { get; }
        private List<string> participio { get; }
        private List<string> traduzione { get; }
        public Verbo(string pres, List<string> pass, List<string> part, List<string> trad)
        {
            presente = pres;
            passato = pass;
            participio = part;
            traduzione = trad;
        }
        internal Verbo()
        {
            presente = "be";
            passato = new List<string> {"was", "were" };
            participio = new List<string> { "been" };
            traduzione = new List<string> { "essere" };
        }
    }

    [Serializable]
    public class ListaVerbi
    {
        public List<Verbo> Lista { get; set; }

        public ListaVerbi()
        {
            Lista = new List<Verbo> { new Verbo()};
        }
        public bool Add(Verbo verb)
        {
            if (Lista.Contains(verb) != true)
            {
                Lista.Add(verb);
                Lista.Sort((p, q) => p.presente.CompareTo(q.presente));
                return true;
            }
            else
                return false;
        }
        public bool Remove(Verbo verb)
        {
            if (Lista.Contains(verb))
            {
                Lista.Remove(verb);
                return true;
            }
            else
                return false;
        }
    }
}
