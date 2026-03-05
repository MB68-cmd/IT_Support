using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Spieler
    {
        public string Name { get; set; }      // Name des Spielers
        public int Energie { get; set; }     // Energie des Spielers, die durch das Sammeln von Gegenständen oder das Lösen von Aufgaben erhöht oder verringert werden kann
        public List<Gegenstand> Inventar { get; set; }  // Liste der Gegenstände, die der Spieler gesammelt hat
        public Spieler(string name)   // Konstruktor, um die Eigenschaften eines Spielers zu setzen, wenn er erstellt wird
        {
            name = name;   // Setzt den Namen des Spielers auf den übergebenen Wert
            Energie = 100;   // Es wird mit voller Energie gestartet, 100
            Inventar = new List<Gegenstand>();  // Initialisiert das Inventar als leere Liste

        }
        public bool HatGegenstand(string name)
        {
            return Inventar.Exists(g => g.Name.ToLower() == name.ToLower());   // Überprüft, ob der Spieler einen Gegenstand mit dem angegebenen Namen im Inventar und Energie hat. Es wird die Methode Exists verwendet, um zu überprüfen, ob es einen Gegenstand im Inventar gibt, dessen Name mit dem angegebenen Namen übereinstimmt (unabhängig von Groß- und Kleinschreibung). Wenn ein solcher Gegenstand gefunden wird, gibt die Methode true zurück, andernfalls false.
        }

    }
}
