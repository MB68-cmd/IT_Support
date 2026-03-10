namespace IT_Support
{
    internal class Raum        // Der Bauplan für die Räume, hier werden die Eigenschaften und Methoden definiert, die alle Räume haben
    {
        public string Name { get; set; }  // Name des Raums, wird bei der Erstellung eines Raums festgelegt
        public string Beschreibung { get; set; }  // Beschreibung des Raums, wird bei der Erstellung eines Raums festgelegt
        public Dictionary<string, Raum> Ausgaenge { get; set; }  // Ein Dictionary, das die möglichen Ausgänge aus diesem Raum definiert, mit der Richtung als Schlüssel und dem Zielraum als Wert
        public List<Gegenstand> GegenstaendeImRaum { get; set; }  // Eine Liste der Gegenstände, die sich in diesem Raum befinden, wird bei der Erstellung eines Raums als leere Liste initialisiert und später mit Gegenständen gefüllt

        public string BenoetigterGegenstand { get; set; }  // Optionaler Gegenstand, der benötigt wird, um diesen Raum zu betreten, z.B. eine Schlüsselkarte für den Serverraum. Wenn null, ist kein Gegenstand erforderlich.
        public Raum(string name, string beschreibung, string benoetigterGegenstand = null)  // Konstruktor, der den Namen, die Beschreibung und den benötigten Gegenstand für den Raum festlegt. Die Ausgänge und Gegenstände im Raum werden als leere Strukturen initialisiert.
        {
            Name = name;  // Setzt den Namen des Raums auf den übergebenen Wert
            Beschreibung = beschreibung;  // Setzt die Beschreibung des Raums auf den übergebenen Wert
            Ausgaenge = new Dictionary<string, Raum>();  // Initialisiert die Ausgänge als leeres Dictionary
            GegenstaendeImRaum = new List<Gegenstand>();  // Initialisiert die Liste der Gegenstände im Raum als leere Liste
            BenoetigterGegenstand = benoetigterGegenstand;  // Setzt den benötigten Gegenstand für den Raum auf den übergebenen Wert, oder null, wenn keiner benötigt wird
        }

        /// <summary>
        /// Diese Methode nimmt die Wahl des Spielers (eine Zahl) und gibt entweder den Zielraum zurück, wenn die Wahl einem Ausgang entspricht, oder den Gegenstand, wenn die Wahl einem Gegenstand im Raum entspricht. Wenn die Wahl ungültig ist, wird null zurückgegeben.
        /// </summary>
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







