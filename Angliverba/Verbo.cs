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
        public List<string> passato { get; }
        public List<string> participio { get; }
        public List<string> traduzione { get; }
        public Verbo(string pres, List<string> pass, List<string> part, List<string> trad)
        {
            presente = pres;
            passato = pass;
            participio = part;
            traduzione = trad;
        }
        public Verbo(Verbo verb)
        {
            presente = verb.presente;
            passato = verb.passato;
            participio = verb.participio;
            traduzione = verb.traduzione;
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
        public List<string> presenti { get; set; }

        public ListaVerbi()
        {
            Lista = new List<Verbo> { new Verbo()};
            presenti = new List<string> { "be" };
        }
        public ListaVerbi(List<Verbo> toBeCopied)
        {
            Lista = toBeCopied;
            presenti = new List<string> {};
            for (int i = 0; i< Lista.Count; i++)
            {
                presenti.Add(Lista[i].presente);
            }
        }
        public bool Add(Verbo verb)
        {
            if (presenti.Contains(verb.presente) != true)
            {
                Lista.Add(verb);
                presenti.Add(verb.presente);
                Lista.Sort((p, q) => p.presente.CompareTo(q.presente));
                presenti.Sort((p, q) => p.CompareTo(q));
                return true;
            }
            else
                return false;
        }
        public bool Remove(string presente)
        {
            if (presenti.Contains(presente))
            {
                int idx = presenti.IndexOf(presente);
                Lista.Remove(Lista[idx]);
                presenti.Remove(presente);
                return true;
            }
            else
                return false;
        }
        public int Count()
        {
            return Lista.Count;
        }
        public Verbo this[int key]
        {
            get => Lista[key];
            set => Lista[key] = value;
        }
        public ListaVerbi shuffle()
        {
            // generate verb list randomly
            List<Verbo> Listarandomized = new List<Verbo> { };
            List<bool> ElementsInserted = new List<bool> { };
            for (int i = 0; i < Lista.Count(); i++)
            {
                ElementsInserted.Add(false);
            }
            for (int i = 0; i < Lista.Count(); i++)
            {
                int index = SeriouslyRandom.Next(0,Lista.Count());
                while (ElementsInserted[index] == true)
                {
                    index = SeriouslyRandom.Next(0,Lista.Count());
                }
                Listarandomized.Add(new Verbo(Lista[index]));
                ElementsInserted[index] = true;
            }

            return new ListaVerbi(Listarandomized);
        }
    }
}
