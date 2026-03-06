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

            Console.WriteLine($"\n{raum.Beschreibung}"); // Nutzt Beschreibung aus der klasse
            Console.WriteLine("-----------------------------------");

            // Statusleiste
            Console.Write($"Energie: {spieler.Energie}% | Inventar: ");
            if (spieler.Inventar.Count == 0) Console.Write("leer");
            foreach (var s in spieler.Inventar) Console.Write("[" + s.Name + "] ");
            Console.WriteLine("\n-----------------------------------");
        }

        static void ZeichneKarte(string raumName)
        {
            // ASCII-Design (ähnlich der vorlage)
            if (raumName == "Flur")
            {
                Console.WriteLine("      |---||xxx|");
                Console.WriteLine("      |    O    |"); // 'O' ist die spielerposition
                Console.WriteLine("      |---||---|");
            }
            else if (raumName == "Büro")
            {
                Console.WriteLine("      |---|| O |");
                Console.WriteLine("      |         |");
                Console.WriteLine("      |---||---|");
            }
            else
            {
                Console.WriteLine("      [ Karte für " + raumName + " folgt ]");
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
