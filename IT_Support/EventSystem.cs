namespace IT_Support
{
    public static class EventSystem
    {
        // Ein Zufallsgenerator, damit nicht immer das Gleiche passiert
        private static Random rnd = new Random();

        /// <summary>
        /// Diese Methode wird aufgerufen, wenn der Spieler einen Raum betritt. Es gibt eine Chance, dass ein zufälliges Event passiert.
        /// </summary>
        internal static void CheckForRandomEvent(Spieler spieler, Raum raum)
        {
            // Es gibt eine 33,33% Chance, dass ein zufälliges Event passiert
            int zahl = rnd.Next(1, 11);

            // Bei einer Zahl von 1 bis 3 passiert ein zufälliges Event
            if (zahl <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n--- ZUFALLSEVENT ---");

                // Es gibt 3 verschiedene Events, die zufällig ausgewählt werden
                int eventTyp = rnd.Next(1, 4);

                switch (eventTyp)
                {
                    case 1:
                        Console.WriteLine(" Ein Kollege fragt: 'Ist das Internet heute wieder langsam?'");
                        Console.WriteLine(" Das nervt dich. Du verlierst 5 Energie.");
                        spieler.Energie -= 10;
                        break;
                    case 2:
                        Console.WriteLine(" Du findest eine ungeöffnete Dose Energy-Drink!");
                        Console.WriteLine(" Du fühlst dich wacher. +10 Energie.");
                        spieler.Energie += 10;
                        break;
                    case 3:
                        Console.WriteLine(" Dein Handy klingelt: 'Der Drucker im 2. Stock brennt!'");
                        Console.WriteLine(" Du ignorierst es.");
                        break;
                }

                Console.ResetColor();
                Console.WriteLine("--------------------\n");
                Console.WriteLine("Drücke eine Taste...");
                Console.ReadKey();
            }
        }
    }
}
