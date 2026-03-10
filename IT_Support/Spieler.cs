namespace IT_Support
{
    internal class Spieler                     // Alle Infos zum Spieler: Name, Energie, Inventar, erledigte Aufgaben
    {
        public string Name { get; set; }      // Name des Spielers, wird zu Beginn abgefragt
        public int Energie { get; set; }      // Energielevel des Spielers, beginnt bei 100 und kann durch Aktionen sinken oder steigen
        public List<Gegenstand> Inventar { get; set; }  // Liste der Gegenstände, die der Spieler gesammelt hat
        public List<string> ErledigteAufgaben { get; set; } = new List<string>();  // Liste der erledigten Aufgaben, hier werden Strings gespeichert, die den Status der Aufgaben repräsentieren 
        public Spieler(string name)  // Konstruktor, der den Namen des Spielers setzt und die anderen Eigenschaften initialisiert
        {
            Name = name;    // Setzt den Namen des Spielers auf den übergebenen Wert
            Energie = 100;  // Startet mit voller Energie
            Inventar = new List<Gegenstand>();  // Initialisiert das Inventar als leere Liste
            ErledigteAufgaben = new List<string>(); ErledigteAufgaben = new List<string>();  // Initialisiert die Liste der erledigten Aufgaben als leere Liste
        }

        public bool HatGegenstand(string name)                       // Prüft, ob der Spieler einen Gegenstand mit dem gegebenen Namen im Inventar
        {
            return Inventar.Exists(g => g.Name.ToLower() == name.ToLower());  // Vergleicht die Namen der Gegenstände im Inventar mit dem gesuchten Namen, unabhängig
        }

    }
}
