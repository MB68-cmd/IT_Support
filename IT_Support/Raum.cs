using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Raum        // Der Bauplan für die Räume, hier werden die Eigenschaften und Methoden definiert, die alle Räume haben
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public Dictionary<string, Raum> Ausgaenge { get; set; }
        public List<Gegenstand> GegenstaendeImRaum { get; set; }
        
        public string BenoetigterGegenstand { get; set; }
        public Raum(string name, string beschreibung, string benoetigterGegenstand = null)
        {
            Name = name;
            Beschreibung = beschreibung;
            Ausgaenge = new Dictionary<string, Raum>();
            GegenstaendeImRaum = new List<Gegenstand>();
            BenoetigterGegenstand = benoetigterGegenstand;  
        }

        public object HoleAktion(int wahl)
        {
            // Ist es ein Ausgang?
            if (wahl > 0 && wahl <= Ausgaenge.Count)
            {
                return Ausgaenge.ElementAt(wahl - 1).Value; // Gibt den Zielraum zurück
            }

            // Ist es ein Gegenstand?
            int gegenstandsIndex = wahl - Ausgaenge.Count - 1;
            if (gegenstandsIndex >= 0 && gegenstandsIndex < GegenstaendeImRaum.Count)
            {
                return GegenstaendeImRaum[gegenstandsIndex]; // Gibt den Gegenstand zurück
            }

            return null; // Ungültige Wahl
        }
    }
}







