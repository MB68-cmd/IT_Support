using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Spieler                           // Alle Infos zum Spieler: Name, Energie, Inventar, erledigte Aufgaben
    {
        public string Name { get; set; }
        public int Energie { get; set; }
        public List<Gegenstand> Inventar { get; set; }
        public List<string> ErledigteAufgaben { get; set; } = new List<string>();
        public Spieler(string name)
        {
            Name = name;
            Energie = 100;
            Inventar = new List<Gegenstand>();
            ErledigteAufgaben = new List<string>(); ErledigteAufgaben = new List<string>();
        }

        public bool HatGegenstand(string name)                       // Prüft, ob der Spieler einen Gegenstand mit dem gegebenen Namen im Inventar
        {
            return Inventar.Exists(g => g.Name.ToLower() == name.ToLower());
        }

    }
}
