namespace IT_Support
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            // 1. INITIALISIERUNG: Welt und Spieler erstellen
            Raum aktuellerRaum = InitialisiereWelt();
            Spieler spieler = new Spieler("IT-Admin");
            bool spielLaeuft = true;

            // 2. HAUPTSCHLEIFE (Game Loop)
            while (spielLaeuft)
            {
                // Interface mit Karte und Status zeichnen
                UI.ZeichneInterface(aktuellerRaum, spieler);

                // Prüfung: Hat der Spieler noch Energie?
                if (spieler.Energie <= 0)
                {
                    Console.WriteLine("\n💀 Deine Energie ist leer! Du brichst zusammen. GAME OVER.");
                    break;
                }

                // Menü-Listen vorbereiten
                var wege = new List<string>(aktuellerRaum.Ausgaenge.Keys);
                var gegenstaende = aktuellerRaum.GegenstaendeImRaum;

                // Menü ausgeben
                UI.ZeichneMenue(wege, gegenstaende);

                // Eingabe verarbeiten
                string eingabe = Console.ReadLine();
                spielLaeuft = VerarbeiteEingabe(eingabe, wege, gegenstaende, ref aktuellerRaum, spieler);
            }

            Console.WriteLine("\nProgramm beendet. Bis bald!");
        }


        // 2. WELT INITIALISIEREN: Räume, Verbindungen und Gegenstände
        static Raum InitialisiereWelt()
        {
            // Räume erstellen
            Raum flur = new Raum("Flur", "Ein langer, heller Flur.");
            Raum buero = new Raum("Büro", "Dein Schreibtisch, voll mit Zetteln.");
            Raum lager = new Raum("Lager", "Überall Kartons mit alten Tastaturen und Kabeln.");
            Raum serverraum = new Raum("Serverraum", "Es ist laut, die LEDs blinken rot!");
            Raum kantine = new Raum("Kantine", "Es riecht nach Essen und Kaffee.");
            Raum chefBuero = new Raum("Chef-Büro", "Luxus Raum mit goldenem Namensschild.");
            Raum werkstatt = new Raum("Werkstatt", "Hier liegt fast alles an Werkzeug.");

            // Wege verbinden
            flur.Ausgaenge.Add("norden", buero);
            flur.Ausgaenge.Add("osten", lager);
            flur.Ausgaenge.Add("westen", serverraum);
            flur.Ausgaenge.Add("süden", kantine);
            buero.Ausgaenge.Add("süden", flur);
            buero.Ausgaenge.Add("norden", chefBuero);
            lager.Ausgaenge.Add("westen", flur);
            lager.Ausgaenge.Add("norden", werkstatt);
            serverraum.Ausgaenge.Add("osten", flur);
            kantine.Ausgaenge.Add("norden", flur);
            chefBuero.Ausgaenge.Add("süden", buero);
            werkstatt.Ausgaenge.Add("süden", lager);

            // Gegenstände verteilen
            kantine.GegenstaendeImRaum.Add(new Gegenstand("Kaffee", "Füllt Energie wieder auf."));
            lager.GegenstaendeImRaum.Add(new Gegenstand("LAN-Kabel", "Wichtig für den Server."));
            chefBuero.GegenstaendeImRaum.Add(new Gegenstand("Schlüsselkarte", "Öffnet den Serverraum."));

            return flur; // Startpunkt
        }

        

        static bool VerarbeiteEingabe(string eingabe, List<string> wege, List<Gegenstand> ding, ref Raum aktuellerRaum, Spieler spieler)
        {
            if (int.TryParse(eingabe, out int wahl))
            {
                if (wahl == 0) return false;

                // Logik: Gehen
                if (wahl > 0 && wahl <= wege.Count)
                {
                    Raum ziel = aktuellerRaum.Ausgaenge[wege[wahl - 1]];

                    // ZUGANGSCHECK: Serverraum
                    if (ziel.Name == "Serverraum" && !spieler.HatGegenstand("Schlüsselkarte"))
                    {
                        Console.WriteLine("\n ZUGRIFF VERWEIGERT! Du brauchst die Schlüsselkarte vom Chef.");
                        Console.WriteLine("Drücke eine Taste...");
                        Console.ReadKey();
                    }
                    else
                    {
                        aktuellerRaum = ziel;
                        spieler.Energie -= 10; // Jeder Schritt kostet Kraft
                    }
                }
                // Logik: Aufheben
                else if (wahl > wege.Count && wahl <= wege.Count + ding.Count)
                {
                    int index = wahl - wege.Count - 1;
                    Gegenstand aufgehoben = ding[index];

                    // Spezial Item Kaffee
                    if (aufgehoben.Name == "Kaffee")
                    {
                        spieler.Energie = 100;
                        Console.WriteLine("\n Du trinkst den Kaffee. Sofortige Energie!");
                    }
                    else
                    {
                        spieler.Inventar.Add(aufgehoben);
                    }

                    ding.RemoveAt(index);
                    Console.WriteLine($"\n>>> {aufgehoben.Name} verarbeitet.");
                    Console.ReadKey();
                }
            }
            return true;
        }
    }

}