using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class UI
    {
        public static void ZeichneInterface(Raum raum, Spieler spieler)
        {
            Console.Clear();
            Console.WriteLine("******************************************");
            Console.WriteLine($" ORT: {raum.Name.ToUpper()}");
            Console.WriteLine("******************************************");

            // Hier wird die Karte gezeichnet
            ZeichneKarte(raum.Name);

            Console.WriteLine($"\n{raum.Beschreibung}"); // Nutzt Beschreibung aus der Klasse
            Console.WriteLine("-----------------------------------");

            // Statusleiste
            Console.Write($"Energie: {spieler.Energie}% | Inventar: ");
            if (spieler.Inventar.Count == 0) Console.Write("leer");
            foreach (var s in spieler.Inventar) Console.Write("[" + s.Name + "] ");
            Console.WriteLine("\n-----------------------------------");
        }


        // ASCII-Design (wird je nach Raum angepasst)
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
                Console.ForegroundColor = ConsoleColor.Cyan; // Blaues Männchen leuchtet im Darkmode super
                Console.Write("O");
            }
            else
            {
                Console.Write(" ");
            }
        }


        public static void ZeichneMenue(List<string> wege, List<Gegenstand> gegenstaende)
        {
            Console.WriteLine("\nWAS MÖCHTEST DU TUN?");

            // Optionen für Wege
            for (int i = 0; i < wege.Count; i++)
            {
                Console.WriteLine($"{i + 1}: Gehe nach {wege[i].ToUpper()}");
            }

            // Optionen für Gegenstände
            for (int i = 0; i < gegenstaende.Count; i++)
            {
                Console.WriteLine($"{wege.Count + i + 1}: {gegenstaende[i].Name} aufheben");
            }

            Console.WriteLine("0: Beenden");
            Console.Write("\nDeine Wahl: ");
        }
    }
}
