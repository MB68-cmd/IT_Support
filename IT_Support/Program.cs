
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

            //  INTRO 
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"
╔═════════════════════════════════════════════════════════════════════════════════╗
║                                                                                 ║
║  ██╗████████╗      ███████╗██╗   ██╗██████╗ ██████╗  ██████╗ ██████╗ ████████╗  ║
║  ██║╚══██╔══╝      ██╔════╝██║   ██║██╔══██╗██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝  ║                                         
║  ██║   ██║   █████╗███████╗██║   ██║██████╔╝██████╔╝██║   ██║██████╔╝   ██║     ║
║  ██║   ██║   ╚════╝╚════██║██║   ██║██╔═══╝ ██╔═══╝ ██║   ██║██╔══██╗   ██║     ║
║  ██║   ██║         ███████║╚██████╔╝██║     ██║     ╚██████╔╝██║  ██║   ██║     ║
║  ╚═╝   ╚═╝         ╚══════╝ ╚═════╝ ╚═╝     ╚═╝      ╚═════╝ ╚═╝  ╚═╝   ██║     ║
║                                                                                 ║
║                              S I M U L A T O R                                  ║
║                                                                                 ║
╚═════════════════════════════════════════════════════════════════════════════════╝
");
            Console.ResetColor();

            Console.WriteLine("\n\n\n Montag Morgen, 08:00 Uhr. Dein Kaffee ist noch heiß.");
            Console.WriteLine(" Plötzlich stürmt ein Kollege herein: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" \tDAS INTERNET IST TOT! \nDER SERVERRAUM BLINKT ROT!");
            Console.ResetColor();

            Console.WriteLine("\n Die Mission:");
            Console.WriteLine(" 1. Finde die SCHLÜSSELKARTE im Büro vom Chef.");
            Console.WriteLine(" 2. Hol dir ein neues LAN-KABEL aus dem Lager.");
            Console.WriteLine(" 3. Repariere den Server, bevor deine Energie leer ist!");

            Console.WriteLine("\n Drücke eine Taste, um den Dienst anzutreten...");
            Console.ReadKey();
            //  ENDE INTRO 


            // HAUPTSCHLEIFE 
            while (spielLaeuft)
            {
                UI.ZeichneInterface(aktuellerRaum, spieler);

                if (spieler.Energie <= 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("DEINE ENERGIE IST AM ENDE.");
                    Console.WriteLine("Du schläfst auf dem Flur ein. Der IT-Support ist gescheitert.");
                    Console.ReadKey();
                    break; // Beendet die While-Schleife -> Programm endet
                }

                // Menü anzeigen
                UI.ZeichneMenue(aktuellerRaum.Ausgaenge, aktuellerRaum.GegenstaendeImRaum, spieler);

                // Eingabe verarbeiten
                string eingabe = Console.ReadLine();
                spielLaeuft = VerarbeiteEingabe(eingabe, ref aktuellerRaum, spieler);
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nProgramm beendet. Bis bald!");
            Console.ResetColor();

        }



        static Raum InitialisiereWelt()
        {
            // Räume 
            Raum flur = new Raum("Flur", "Ein langer, heller Flur.");
            Raum buero = new Raum("Büro", "Dein Schreibtisch, voll mit Zetteln.");
            Raum lager = new Raum("Lager", "Überall Kartons mit alten Tastaturen und Kabeln.");
            Raum serverraum = new Raum("Serverraum", "Es ist laut...", "Schlüsselkarte");
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
            lager.Ausgaenge.Add("süden", werkstatt);
            serverraum.Ausgaenge.Add("osten", flur);
            kantine.Ausgaenge.Add("norden", flur);
            chefBuero.Ausgaenge.Add("süden", buero);
            werkstatt.Ausgaenge.Add("süden", lager);

            // Gegenstände verteilen
            kantine.GegenstaendeImRaum.Add(new Gegenstand("Kaffee", "Füllt Energie wieder auf."));
            lager.GegenstaendeImRaum.Add(new Gegenstand("LAN-Kabel", "Wichtig für den Server."));
            chefBuero.GegenstaendeImRaum.Add(new Gegenstand("Schlüsselkarte", "Öffnet den Serverraum."));

            return buero; // Startpunkt
        }



        static bool VerarbeiteEingabe(string eingabe, ref Raum aktuellerRaum, Spieler spieler)
        {
            if (string.IsNullOrWhiteSpace(eingabe)) return true;

            string befehl = eingabe.ToLower().Trim();

            // Exit-Check: Wenn der Spieler "ende", "exit" oder "quit" eingibt, beenden wir das Spiel
            if (befehl == "ende" || befehl == "exit" || befehl == "quit")
            {
                return false;
            }

            // Bewegungslogik: Wir prüfen, ob die Eingabe eine Richtung enthält, die im aktuellen Raum als Ausgang definiert ist
            foreach (var richtung in aktuellerRaum.Ausgaenge.Keys)
            {
                if (befehl.Contains(richtung)) // Prüft ob norden in gehe norden steckt
                {
                    Raum ziel = aktuellerRaum.Ausgaenge[richtung];

                    // Zugangscheck
                    if (ziel.BenoetigterGegenstand != null && !spieler.HatGegenstand(ziel.BenoetigterGegenstand))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n [!] ZUGRIFF VERWEIGERT! Die Tür ist gesperrt. Du benötigst die {ziel.BenoetigterGegenstand} aus dem Chef-Büro.");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                    else
                    {
                        aktuellerRaum = ziel;
                        spieler.Energie -= 10;
                        EventSystem.CheckForRandomEvent(spieler, aktuellerRaum);
                    }
                    return true;
                }
            }

            // Item Logik 
            foreach (var item in aktuellerRaum.GegenstaendeImRaum.ToList())
            {
                if (befehl.Contains(item.Name.ToLower()))
                {
                    if (item.Name == "Kaffee")
                    {
                        spieler.Energie = 100;
                        Console.WriteLine("\n Energie voll!");
                    }
                    else
                    {
                        spieler.Inventar.Add(item);
                        Console.WriteLine($"\n {item.Name} aufgehoben.");
                    }
                    aktuellerRaum.GegenstaendeImRaum.Remove(item);
                    Console.ReadKey();
                    return true;
                }
            }
            // Benutzen Logik
            if (befehl.StartsWith("benutze"))
            {
                foreach (var item in spieler.Inventar.ToList())
                {
                    if (befehl.Contains(item.Name.ToLower()))
                    {
                        // Wir rufen die Methode auf, die in der Klasse Gegenstand steht
                        Gegenstand.BenutzeGegenstand(item, spieler, ref aktuellerRaum);
                        return true;
                    }
                }
            }

            // Wenn wir hier landen, dann hat die Eingabe keinen bekannten Befehl oder Gegenstand enthalten
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n [?] Ich verstehe diesen Befehl nicht. Probiere 'gehe ...' oder 'nimm ...'.");
            Console.ResetColor();
            Console.ReadKey();

            return true;
        }


    }

}