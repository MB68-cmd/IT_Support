using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Gegenstand
    {
        public string Name { get; set; }  // Name des Gegenstands

        public string Beschreibung { get; set; }  // Beschreibung des Gegenstands
        public Gegenstand(string name, string beschreibung)  // Konstruktor  // Bauplan: Erstellt einen neuen Gegenstand
        {
            Name = name;                     // Setzt den Namen des Gegenstands auf den übergebenen Wert
            Beschreibung = beschreibung;     // Setzt die Beschreibung des Gegenstands auf den übergebenen Wert
        }

    }
}
