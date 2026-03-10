using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class UI
    {
        // Zeichnet das Hauptinterface mit Raumname, Beschreibung, Karte, Inventar und Aufgaben
        public static void ZeichneInterface(Raum raum, Spieler spieler)
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine($" ORT: {raum.Name.ToUpper()}");
            Console.WriteLine("******************************************");

            
            Console.WriteLine($"\n{raum.Beschreibung}"); // Nutzt Beschreibung aus der Klasse
            Console.WriteLine("-----------------------------------");

            ZeichneKarte(raum.Name);  // Zeichnet die Karte mit Spielerposition


            // Inventar und Energieanzeige
            if (spieler.Energie < 30) Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Inventar: ");
            if (spieler.Inventar.Count == 0) Console.Write("leer");
            foreach (var s in spieler.Inventar) Console.Write("[" + s.Name + "] ");
            Console.WriteLine("\n-----------------------------------");
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

            Console.Write($"Energie: {spieler.Energie}%");
            Console.ResetColor();
        }


        // Zeichnet die Karte mit einem "O" an der Position des Spielers
        public static void ZeichneKarte(string raumName)
        {
            string pFlur = " ", pBuero = " ", pLager = " ", pServer = " ", pKantine = " ", pChef = " ", pWerk = " ";

            switch (raumName)
            {
                case "Flur": pFlur = "O"; break;
                case "Büro": pBuero = "O"; break;
                case "Lager": pLager = "O"; break;
                case "Serverraum": pServer = "O"; break;
                case "Kantine": pKantine = "O"; break;
                case "Chef-Büro": pChef = "O"; break;
                case "Werkstatt": pWerk = "O"; break;
            }

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

        public static void ZeichneO(string p)
        {
            if (p == "O")
            {
                Console.ForegroundColor = ConsoleColor.Cyan; 
                Console.Write("O");
            }
            else
            {
                Console.Write(" ");
            }
        }

        // Das Menü zeigt die möglichen Befehle an, basierend auf den Ausgängen und Gegenständen im Raum sowie dem Inventar des Spielers
        public static void ZeichneMenue(Dictionary<string, Raum> ausgaenge, List<Gegenstand> gegenstaende, Spieler spieler)
        {
            Console.WriteLine("\n--- DEINE BEFEHLE ---");

            foreach (var richtung in ausgaenge.Keys)
            {
                Console.WriteLine($" > gehe {richtung.ToUpper()}");
            }

            foreach (var item in gegenstaende)
            {
                Console.WriteLine($" > nimm {item.Name.ToUpper()}");
            }

            foreach (var item in spieler.Inventar)
            {
                Console.WriteLine($" > benutze {item.Name.ToUpper()}");
            }

            Console.WriteLine(" > ende");
            Console.Write("\n Was willst du tun? ");

        }
    }
}
