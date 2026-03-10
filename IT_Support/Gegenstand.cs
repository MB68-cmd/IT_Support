using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Support
{
    internal class Gegenstand
    {
        // Name 
        public string Name { get; set; }
        // Beschreibung 
        public string Beschreibung { get; set; }

        // Erstellt einen neuen Gegenstand
        public Gegenstand(string name, string beschreibung)
        {
            Name = name;
            Beschreibung = beschreibung;
        }
        // Logik für die Benutzung von Gegenständen
        public static void BenutzeGegenstand(Gegenstand item, Spieler spieler, ref Raum aktuellerRaum)
        {
            Console.WriteLine($"\nDu benutzt: {item.Name}...");
            
            switch (item.Name)
            {
                
                case "LAN-Kabel":
                    if (aktuellerRaum.Name == "Serverraum")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n [REPARATUR] Du schließt das LAN-Kabel an den Haupt-Switch an.");
                        Console.WriteLine(" Die LEDs springen von Orange auf Grün. Das Netz lebt!");
                        Console.Clear();
                        Console.WriteLine("========================================");
                        Console.WriteLine("   S I E G ! ! !");
                        Console.WriteLine("========================================");
                        Console.WriteLine("Du hast das Kabel eingesteckt.");
                        Console.WriteLine("Die Server leuchten grün. Das Internet läuft!");
                        Console.WriteLine("\nDrücke eine Taste, um in den Feierabend zu gehen...");
                        Console.ReadKey();

                        Environment.Exit(0); // Beendet das Spiel sofort
                    }
                    else
                    {
                        Console.WriteLine("Hier kannst du das Kabel nicht gebrauchen.");
                    }
                    break;

                case "Schlüsselkarte":
                    Console.WriteLine("Die Karte wird automatisch beim Betreten des Serverraums geprüft.");
                    break;

                    
            }
            Console.ReadKey();
        }
    }
}
