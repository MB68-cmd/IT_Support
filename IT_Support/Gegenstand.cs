namespace IT_Support
{

    internal class Gegenstand
    {
        
        public string Name { get; set; }    // Neme
        
        public string Beschreibung { get; set; } // 

        /// <summary>
        /// Erstellt einen neuen Gegenstand
        /// </summary>
        /// <param name="name"
        /// <param name="beschreibung"
        public Gegenstand(string name, string beschreibung)
        {
            Name = name;
            Beschreibung = beschreibung;
        }

        /// <summary>
        /// Benutzt einen Gegenstand, abhängig von seiner Art und dem aktuellen Raum
        /// </summary>
        /// <param name="item"></param>
        /// <param name="spieler"></param>
        /// <param name="aktuellerRaum"></param>
        public static void BenutzeGegenstand(Gegenstand item, Spieler spieler, ref Raum aktuellerRaum)             // Benötigt wird der Gegenstand, der Spieler, und der aktuelle Raum (ref, da er sich ändern könnte)
        {
            Console.WriteLine($"\nDu benutzt: {item.Name}...");
            
            switch (item.Name)              // Je nach Gegenstand, wird eine andere Aktion ausgeführt. Es könnte sein, dass der Gegenstand in diesem Raum nicht benutzt werden kann, oder dass er automatisch beim Betreten des Raums geprüft 
            {

                case "LAN-Kabel":          // Das LAN-Kabel kann nur im Serverraum benutzt werden, um die Reparatur abzuschließen
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

                // Die Schlüsselkarte wird automatisch beim Betreten des Serverraums geprüft, um Zugang zu gewähren. Sie muss nicht manuell benutzt werden.
                case "Schlüsselkarte":
                    Console.WriteLine("Die Karte wird automatisch beim Betreten des Serverraums geprüft.");  
                    break;


            }
            Console.ReadKey();
        }
    }
}
