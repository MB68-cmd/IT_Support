namespace IT_Support
{
    /// <summary>
    /// Die UI-Klasse ist für die Darstellung des Spiels zuständig: Sie zeichnet das Hauptinterface, die Karte und das Menü mit den möglichen Befehlen
    /// </summary>
    internal class UI
    {
        /// <summary>
        /// Zeichnet das Hauptinterface mit Raumname, Beschreibung, Karte, Inventar und Aufgaben
        /// </summary>
        public static void ZeichneInterface(Raum raum, Spieler spieler)                 
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine($" ORT: {raum.Name.ToUpper()}");                          // Zeigt den Namen des aktuellen Raums an
            Console.WriteLine("******************************************");


            Console.WriteLine($"{raum.Beschreibung}\n\n");                                // Nutzt Beschreibung aus der Klasse

            ZeichneKarte(raum.Name);                                                    // Zeichnet die Karte mit Spielerposition


            // Inventar und Energieanzeige

            if (spieler.Energie < 30) Console.ForegroundColor = ConsoleColor.Red;         // Warnung bei niedrigem Energielevel
            else Console.ForegroundColor = ConsoleColor.DarkYellow; Console.ResetColor();  // Normalfarbe bei ausreichender Energie

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nInventar: ");
            if (spieler.Inventar.Count == 0) Console.Write("leer");                     // Zeigt den Inhalt des Inventars an oder "leer", wenn nichts drin ist
            foreach (var s in spieler.Inventar) Console.Write("[" + s.Name + "] ");     // Listet die Gegenstände im Inventar auf
            Console.WriteLine("\n-----------------------------------"); 
            Console.ResetColor();

            // Aufgabenliste mit Status
            Console.WriteLine("\n--- AKTUELLE AUFGABEN ---");

            if (!spieler.HatGegenstand("Schlüsselkarte"))
                Console.WriteLine(" [ ] Hol die Schlüsselkarte vom Chef.");
            else
                Console.WriteLine(" [X] Schlüsselkarte gefunden!");

            if (!spieler.HatGegenstand("LAN-Kabel"))
                Console.WriteLine(" [ ] Finde ein Ersatz-Kabel im Lager.");
            else
                Console.WriteLine(" [X] LAN-Kabel eingepackt!");

            if (spieler.ErledigteAufgaben.Contains("ServerRepariert"))
                Console.WriteLine(" [X] Internet wiederhergestellt!");
            else
                Console.WriteLine(" [ ] Repariere den Server im Serverraum.");

            Console.WriteLine($"\nEnergie: {spieler.Energie}%\n");
            Console.ResetColor();
        }


        /// <summary>
        /// Zeichnet die Karte mit einem "O" an der Position des Spielers
        /// </summary>
        
        public static void ZeichneKarte(string raumName)     // Nimmt den Namen des aktuellen Raums als Parameter, um die Position des Spielers zu markieren
        {
            string pFlur = " ", pBuero = " ", pLager = " ", pServer = " ", pKantine = " ", pChef = " ", pWerk = " ";

            switch (raumName)  // Je nach aktuellem Raum wird das "O" an der entsprechenden Stelle gesetzt
            {
                case "Flur": pFlur = "O"; break;
                case "Büro": pBuero = "O"; break;
                case "Lager": pLager = "O"; break;
                case "Serverraum": pServer = "O"; break;
                case "Kantine": pKantine = "O"; break;
                case "Chef-Büro": pChef = "O"; break;
                case "Werkstatt": pWerk = "O"; break;
            }


            // Karte zeichnen mit ASCII-Art, die Räume sind in einer festen Anordnung dargestellt, damit der Spieler sich orientieren kann

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("              ┌─────────┐");
            Console.Write("              │   "); ZeichneO(pChef); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     │  Chef-Büro");
            Console.WriteLine("              └────┬────┘");
            Console.WriteLine("                   │");

            Console.WriteLine("              ┌─────────┐");
            Console.Write("              │   "); ZeichneO(pBuero); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     │  Büro");
            Console.WriteLine("              └────┬────┘");
            Console.WriteLine("                   │");

            Console.WriteLine("┌─────────┐   ┌─────────┐   ┌─────────┐");
            Console.Write("│   "); ZeichneO(pServer); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("     │───│   "); ZeichneO(pFlur); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("     │───│   "); ZeichneO(pLager); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     │");
            Console.WriteLine("│Serverraum│   │   Flur  │   │  Lager  │");
            Console.WriteLine("└─────────┘   └────┬────┘   └────┬────┘");
            Console.WriteLine("                   │             │");

            Console.WriteLine("              ┌─────────┐   ┌─────────┐");
            Console.Write("              │   "); ZeichneO(pKantine); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("     │   │   "); ZeichneO(pWerk); Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("     │");
            Console.WriteLine("              │ Kantine │   │Werkstatt│");
            Console.WriteLine("              └─────────┘   └─────────┘");

            Console.ResetColor();
        }


        /// <summary>
        /// Hilfsmethode zum Zeichnen eines "O" an der Position des Spielers auf der Karte
        /// </summary>
        public static void ZeichneO(string p)              // Nimmt einen String als Parameter, der entweder "O" oder " " sein kann, um die Position des Spielers zu markieren
        {
            if (p == "O")                                 // Wenn der Spieler sich in diesem Raum befindet, wird ein "O" gezeichnet
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("O");
            }
            else
            {
                Console.Write(" ");                       // Ansonsten bleibt die Stelle leer
            }
        }          

        /// <summary>
        /// Das Menü zeigt die möglichen Befehle an, basierend auf den Ausgängen und Gegenständen im Raum sowie dem Inventar des Spielers
        /// </summary>
        public static void ZeichneMenue(Dictionary<string, Raum> ausgaenge, List<Gegenstand> gegenstaende, Spieler spieler)   // Nimmt die verfügbaren Ausgänge, Gegenstände im Raum und den Spieler als Parameter, um die möglichen Befehle anzuzeigen
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n--- DEINE BEFEHLE ---");

            foreach (var richtung in ausgaenge.Keys)                        // Zeigt die verfügbaren Richtungen an, in die der Spieler gehen kann
            {
                Console.WriteLine($" > gehe {richtung.ToUpper()}");
            }

            foreach (var item in gegenstaende)                              // Zeigt die Gegenstände im Raum an, die der Spieler aufnehmen kann
            {
                Console.WriteLine($" > nimm {item.Name.ToUpper()}");
            }

            foreach (var item in spieler.Inventar)                          // Zeigt die Gegenstände im Inventar an, die der Spieler benutzen kann
            {
                Console.WriteLine($" > benutze {item.Name.ToUpper()}"); 
            }

            Console.WriteLine(" > ende");
            Console.ResetColor();

            Console.WriteLine("\n Was willst du tun? ");

        }
    }
}
