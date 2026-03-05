using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Raum        // Der Bauplan für die Räume, hier werden die Eigenschaften und Methoden definiert, die alle Räume haben
    {
        public string Name { get; set; }    // Name des Raumes
        public string Beschreibung { get; set; }  // Beschreibung des Raumes

        public Dictionary<string, Raum> Ausgaenge { get; set; }  // Dictionary, um die Ausgänge zu anderen Räumen zu speichern, der Schlüssel ist die Richtung (z.B. "norden") und der Wert ist der

        public List<Gegenstand> GegenstaendeImRaum { get; set; }  // Liste der Gegenstände, die sich im Raum befinden


        public Raum(string name, string beschreibung)   // Konstruktor, um die Eigenschaften eines Raumes zu setzen, wenn er erstellt wird
        {
            Name = name;  // Setzt den Namen des Raumes auf den übergebenen Wert
            Beschreibung = beschreibung;  // Setzt die Beschreibung des Raumes
            Ausgaenge = new Dictionary<string, Raum>();  // Initialisiert die Ausgänge als leeres Dictionary
            GegenstaendeImRaum = new List<Gegenstand>(); // Initialisiert die Liste der Gegenstände im Raum als leere Liste
        }
    }
}
